    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public struct TestStruct // Mutable for brevity; real structs should be immutable.
            {
                public byte   ByteValue;
                public short  ShortValue;
                public int    IntValue;
                public long   LongValue;
                public float  FloatValue;
                public double DoubleValue;
            }
            static void Main()
            {
                var array = new TestStruct[10];
                for (byte i = 0; i < array.Length; ++i)
                {
                    array[i].ByteValue   = i;
                    array[i].ShortValue  = i;
                    array[i].IntValue    = i;
                    array[i].LongValue   = i;
                    array[i].FloatValue  = i;
                    array[i].DoubleValue = i;
                }
                Directory.CreateDirectory("C:\\TEST");
                using (var output = new FileStream(@"C:\TEST\TEST.BIN", FileMode.Create))
                    FastWrite(output, array, 0, array.Length);
                using (var input = new FileStream(@"C:\TEST\TEST.BIN", FileMode.Open))
                    array = FastRead<TestStruct>(input, array.Length);
                for (byte i = 0; i < array.Length; ++i)
                {
                    Trace.Assert(array[i].ByteValue   == i);
                    Trace.Assert(array[i].ShortValue  == i);
                    Trace.Assert(array[i].IntValue    == i);
                    Trace.Assert(array[i].LongValue   == i);
                    Trace.Assert(array[i].FloatValue  == i);
                    Trace.Assert(array[i].DoubleValue == i);
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
                            fs.SafeFileHandle,
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
                if (availableValues == 0)
                    return result;
                GCHandle gcHandle = GCHandle.Alloc(result, GCHandleType.Pinned);
                try
                {
                    uint bytesRead;
                    if
                    (
                        !ReadFile
                        (
                            fs.SafeFileHandle,
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
            [DllImport("kernel32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool ReadFile
            (
                SafeFileHandle hFile,
                IntPtr lpBuffer,
                uint nNumberOfBytesToRead,
                out uint lpNumberOfBytesRead,
                IntPtr lpOverlapped
            );
            /// <summary>See the Windows API documentation for details.</summary>
            [DllImport("kernel32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool WriteFile
            (
                SafeFileHandle hFile,
                IntPtr lpBuffer,
                uint nNumberOfBytesToWrite,
                out uint lpNumberOfBytesWritten,
                IntPtr lpOverlapped
            );
        }
    }
 
