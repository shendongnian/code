        public bool TryDetectNewLine(string path, out string newLine)
        {
            using (var fileStream = File.OpenRead(path))
            {
                char prevChar = '\0';
                // Read the first 4000 characters to try and find a newline
                for (int i = 0; i < 4000; i++)
                {
                    int b;
                    if ((b = fileStream.ReadByte()) == -1) break;
                    char curChar = (char)b;
                    if (curChar == '\n')
                    {
                        newLine = prevChar == '\r' ? "\r\n" : "\n";
                        return true;
                    }
                    prevChar = curChar;
                }
                // Returning false means could not determine linefeed convention
                newLine = Environment.NewLine;
                return false;
            }
        }
