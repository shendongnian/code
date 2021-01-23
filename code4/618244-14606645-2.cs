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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId="System.Runtime.InteropServices.SafeHandle.DangerousGetHandle")]
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
                Debug.WriteLine("Requested data exceeds available data and partial data remains in the file.");
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
    }
}
