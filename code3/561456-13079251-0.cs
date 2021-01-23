    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class AssemblyUtility
    {
        /// <summary>
        /// The value 'PE\0\0'
        /// </summary>
        private const uint PeHeaderValue = 0x4550;
        /// <summary>
        /// Image file value found at start of PE header that indicates assembly is 64bit.
        /// </summary>
        private const ushort ImageFileMachineAmd64 = 0x8664;
        /// <summary>
        /// The offset to PIMAGE_DOS_HEADER->e_lfanew
        /// </summary>
        private const int DosHeaderLfaNewOffset = 0x3c;
        /// <summary>
        /// Checks to see if the module is a 64 bit
        /// </summary>
        /// <param name="path">The path to the assembly.</param>
        /// <returns>
        /// True if is 64bit
        /// </returns>
        public static bool Is64BitImage(string path)
        {
            return ReadImageMachineType(path) == MachineType.ImageFileMachineAMD64;
        }
        /// <summary>
        /// Reads the machine type from the pe header.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <returns>The assembly machinetype.</returns>
        public static MachineType ReadImageMachineType(string path)
        {
            // The memory layout varies depending on 32/64 bit.  The portions of the PE header we are reading should be the same though regardless.
            byte[] buffer = new byte[4];
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // skip to PIMAGE_DOS_HEADER->e_lfanew of dos header.
                fileStream.Seek(DosHeaderLfaNewOffset, SeekOrigin.Begin);
                // read and jump to offset in PIMAGE_DOS_HEADER->e_lfanew.  This is start of PIMAGE_NT_HEADERS
                fileStream.Read(buffer, 0, 4);
                fileStream.Seek(BitConverter.ToUInt32(buffer, 0), SeekOrigin.Begin);
                // Validate PE\0\0 header.
                fileStream.Read(buffer, 0, 4);
                if (BitConverter.ToUInt32(buffer, 0) != PeHeaderValue)
                {
                    throw new TestRunnerException(string.Format(CultureInfo.InvariantCulture, "The specified assembly '{0}' does not appear to be valid.", path));
                }
                // Read the PIMAGE_FILE_HEADER->Machine value. 
                fileStream.Read(buffer, 0, 2);
                return (MachineType)BitConverter.ToUInt16(buffer, 0);
            }
        }
        /// <summary>
        /// Safely loads the assembly.
        /// </summary>
        /// <param name="path">The path to the assembly to load.</param>
        /// <returns>The loaded assembly</returns>
        public static Assembly SafeLoadAssembly(string path)
        {
            try
            {
                return Assembly.Load(path);
            }
            catch (ArgumentNullException)
            {
            }
            catch (FileNotFoundException)
            {
            }
            catch (FileLoadException)
            {
            }
            catch (BadImageFormatException)
            {
            }
            return null;
        }
    }
}
