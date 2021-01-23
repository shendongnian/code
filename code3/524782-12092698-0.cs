    public static class Program
    {
        public static void Main()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;
                    // Append password characters into the SecureString
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                Console.WriteLine();
                // Password entered, display it for demonstration purposes
                DisplaySecureString(ss);
            }
            // After 'using', the SecureString is Disposed; no sensitive data in memory
        }
        // This method is unsafe because it accesses unmanaged memory
        private unsafe static void DisplaySecureString(SecureString ss)
        {
            Char* pc = null;
            try
            {
                // Decrypt the SecureString into an unmanaged memory buffer
                pc = (Char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
                // Access the unmanaged memory buffer that
                // contains the decrypted SecureString
                for (Int32 index = 0; pc[index] != 0; index++)
                    Console.Write(pc[index]);
            }
            finally
            {
                // Make sure we zero and free the unmanaged memory buffer that contains
                // the decrypted SecureString characters
                if (pc != null)
                    Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
            }
        }
    }
