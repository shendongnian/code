    /// <summary>
    /// Utility class to read last line from a utf-8 text file in a performance sensitive way. The code does not handle a case where more than one line is written at once.
    /// </summary>
    public static class UTF8FileLastLineReader
    {
        /// <summary>
        /// Read the last line from the file. This method assumes that each write to the file will be terminated with a new line char ('\n')
        /// </summary>
        /// <param name="path">Path of the file to read</param>
        /// <returns>The last line or null if a line could not be read (empty file or partial line write in progress)</returns>
        /// <exception cref="Exception">Opening or reading from file fails</exception>
        public static string ReadLastLineFromUTF8EncodedFile(string path)
        {
            // open read only, we don't want any chance of writing data
            using (System.IO.Stream fs = System.IO.File.OpenRead(path))
            {
                // check for empty file
                if (fs.Length == 0)
                {
                    return null;
                }
                // start at end of file
                fs.Position = fs.Length - 1;
                // the file must end with a '\n' char, if not a partial line write is in progress
                int byteFromFile = fs.ReadByte();
                if (byteFromFile != '\n')
                {
                    // partial line write in progress, do not return the line yet
                    return null;
                }
                // move back to the new line byte - the loop will decrement position again to get to the byte before it
                fs.Position--;
                // while we have not yet reached start of file, read bytes backwards until '\n' byte is hit
                while (fs.Position > 0)
                {
                    fs.Position--;
                    byteFromFile = fs.ReadByte();
                    if (byteFromFile < 0)
                    {
                        // the only way this should happen is if someone truncates the file out from underneath us while we are reading backwards
                        throw new System.IO.IOException("Error reading from file at " + path);
                    }
                    else if (byteFromFile == '\n')
                    {
                        // we found the new line, break out, fs.Position is one after the '\n' char
                        break;
                    }
                    fs.Position--;
                }
                // fs.Position will be right after the '\n' char or position 0 if no '\n' char
                byte[] bytes = new System.IO.BinaryReader(fs).ReadBytes((int)(fs.Length - fs.Position));
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
