        /// <summary>
        /// https://www.pinvoke.net/default.aspx/shell32/CommandLineToArgvW.html
        /// </summary>
        /// <param name="unsplitArgumentLine"></param>
        /// <returns></returns>
        static string[] SplitArgs(string unsplitArgumentLine)
        {
            int numberOfArgs;
            IntPtr ptrToSplitArgs;
            string[] splitArgs;
            ptrToSplitArgs = CommandLineToArgvW(unsplitArgumentLine, out numberOfArgs);
            // CommandLineToArgvW returns NULL upon failure.
            if (ptrToSplitArgs == IntPtr.Zero)
                throw new ArgumentException("Unable to split argument.", new Win32Exception());
            // Make sure the memory ptrToSplitArgs to is freed, even upon failure.
            try
            {
                splitArgs = new string[numberOfArgs];
                // ptrToSplitArgs is an array of pointers to null terminated Unicode strings.
                // Copy each of these strings into our split argument array.
                for (int i = 0; i < numberOfArgs; i++)
                    splitArgs[i] = Marshal.PtrToStringUni(
                        Marshal.ReadIntPtr(ptrToSplitArgs, i * IntPtr.Size));
                return splitArgs;
            }
            finally
            {
                // Free memory obtained by CommandLineToArgW.
                LocalFree(ptrToSplitArgs);
            }
        }
        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine,
            out int pNumArgs);
        [DllImport("kernel32.dll")]
        static extern IntPtr LocalFree(IntPtr hMem);
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static string GetEscapedCommandLine()
        {
            StringBuilder sb = new StringBuilder();
            bool gotQuote = false;
            foreach (var c in Environment.CommandLine.Reverse())
            {
                if (c == '"')
                    gotQuote = true;
                else if (gotQuote && c == '\\')
                {
                    // double it
                    sb.Append('\\');
                }
                else
                    gotQuote = false;
                sb.Append(c);
            }
            return Reverse(sb.ToString());
        }
        static void Main(string[] args)
        {
            // Crazy hack
            args = SplitArgs(GetEscapedCommandLine()).Skip(1).ToArray();
        }
