    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        public static class Program
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 108)]
            public struct PreIndexStruct
            {
                public unsafe fixed byte Key[96];
                public long Offset;
                public int Count;
            }
            private static void Main(string[] args)
            {
                PreIndexStruct[] a = new PreIndexStruct[100];
                for (int i = 0; i < a.Length; ++i)
                {
                    a[i].Count = i;
                    unsafe
                    {
                        fixed (byte* key = a[i].Key)
                        {
                            for (int j = 0; j < 10; ++j)
                            {
                                key[j] = (byte)i;
                            }
                        }
                    }
                }
                using (var output = File.Create(@"C:\TEST\TEST.BIN"))
                {
                    FastWrite(output, a, 0, a.Length);
                }
                using (var input = File.OpenRead(@"C:\TEST\TEST.BIN"))
                {
                    var b = FastRead<PreIndexStruct>(input, a.Length);
                    for (int i = 0; i < b.Length; ++i)
                    {
                        Console.Write("Count = " + b[i].Count + ", Key =");
                        unsafe
                        {
                            fixed (byte* key = b[i].Key)
                            {
                                // Here you would access the bytes in Key[], which would presumably be ANSI chars.
                                for (int j = 0; j < 10; ++j)
                                {
                                    Console.Write(" " + key[j]);
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            /// <summary>
            /// Writes a part of an array to a file stream as quickly as possible,
            /// without making any additional copies of the data.
            /// </summary>
            /// <typeparam name="T">The type of the array elements.</typeparam>
            /// <param name="fs">The file stream to which to write.</param>
            /// <param name="array">The array containing the data to write.</param>
            /// <param name="offset">The offset of the start of the data in the array to write.</param>
            /// <param name="count">The number of array elements to write.</param>
            /// <exception cref="IOException">Thrown on error. See inner exception for <see cref="Win32Exception"/></exception>
            [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId="System.Runtime.InteropServices.SafeHandle.DangerousGetHandle")]
        
            public static void FastWrite<T>(FileStream fs, T[] array, int offset, int count) where T: struct
            {
                int sizeOfT = Marshal.SizeOf(typeof(T));
                GCHandle gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                try
                {
                    uint bytesWritten;
                    uint bytesToWrite = (uint)(count * sizeOfT);
                    if
                    (
                        !WriteFile
                        (
                            fs.SafeFileHandle.DangerousGetHandle(),
                            new IntPtr(gcHandle.AddrOfPinnedObject().ToInt64() + (offset*sizeOfT)),
                            bytesToWrite,
                            out bytesWritten,
                            IntPtr.Zero
                        )
                    )
                    {
                        throw new IOException("Unable to write file.", new Win32Exception(Marshal.GetLastWin32Error()));
                    }
                    Debug.Assert(bytesWritten == bytesToWrite);
                }
                finally
                {
                    gcHandle.Free();
                }
            }
            /// <summary>
            /// Reads array data from a file stream as quickly as possible,
            /// without making any additional copies of the data.
            /// </summary>
            /// <typeparam name="T">The type of the array elements.</typeparam>
            /// <param name="fs">The file stream from which to read.</param>
            /// <param name="count">The number of elements to read.</param>
            /// <returns>
            /// The array of elements that was read. This may be less than the number that was
            /// requested if the end of the file was reached. It may even be empty.
            /// NOTE: There may still be data left in the file, even if not all the requested
            /// elements were returned - this happens if the number of bytes remaining in the
            /// file is less than the size of the array elements.
            /// </returns>
            /// <exception cref="IOException">Thrown on error. See inner exception for <see cref="Win32Exception"/></exception>
            [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId="System.Runtime.InteropServices.SafeHandle.DangerousGetHandle")]
        
            public static T[] FastRead<T>(FileStream fs, int count) where T: struct
            {
                int sizeOfT = Marshal.SizeOf(typeof(T));
                long bytesRemaining  = fs.Length - fs.Position;
                long wantedBytes     = count * sizeOfT;
                long bytesAvailable  = Math.Min(bytesRemaining, wantedBytes);
                long availableValues = bytesAvailable / sizeOfT;
                long bytesToRead     = (availableValues * sizeOfT);
                if ((bytesRemaining < wantedBytes) && ((bytesRemaining - bytesToRead) > 0))
                {
                    Debug.WriteLine("Requested data exceeds available data and partial data remains in the file.", "Dmr.Common.IO.Arrays.FastRead(fs,count)");
                }
                T[] result = new T[availableValues];
                GCHandle gcHandle = GCHandle.Alloc(result, GCHandleType.Pinned);
                try
                {
                    uint bytesRead = 0;
                    if
                    (
                        !ReadFile
                        (
                            fs.SafeFileHandle.DangerousGetHandle(),
                            gcHandle.AddrOfPinnedObject(),
                            (uint)bytesToRead,
                            out bytesRead,
                            IntPtr.Zero
                        )
                    )
                    {
                        throw new IOException("Unable to read file.", new Win32Exception(Marshal.GetLastWin32Error()));
                    }
                    Debug.Assert(bytesRead == bytesToRead);
                }
                finally
                {
                    gcHandle.Free();
                }
                return result;
            }
            /// <summary>See the Windows API documentation for details.</summary>
            [SuppressMessage("Microsoft.Interoperability", "CA1415:DeclarePInvokesCorrectly")]
            [DllImport("kernel32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool ReadFile
            (
                IntPtr hFile,
                IntPtr lpBuffer,
                uint nNumberOfBytesToRead,
                out uint lpNumberOfBytesRead,
                IntPtr lpOverlapped
            );
            /// <summary>See the Windows API documentation for details.</summary>
            [SuppressMessage("Microsoft.Interoperability", "CA1415:DeclarePInvokesCorrectly")]
            [DllImport("kernel32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool WriteFile
            (
                IntPtr hFile,
                IntPtr lpBuffer,
                uint nNumberOfBytesToWrite,
                out uint lpNumberOfBytesWritten,
                IntPtr lpOverlapped
            );
        }
    }
