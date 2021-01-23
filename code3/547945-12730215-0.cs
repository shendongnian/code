    using System;
    using System.IO;
    public class Program
    {
        public static void WriteFile(int aFileIndex, byte[] sourceBytes, int firstByteIndex, int byteCount)
        {
            string filename = String.Format("output{0}.pvr", aFileIndex);
            byte[] outputBytes = new byte[byteCount];
            Array.Copy(sourceBytes, firstByteIndex, outputBytes, 0, byteCount);
            File.WriteAllBytes(filename, outputBytes);
        }
        public static void Main()
        {
            byte[] fileBytes = File.ReadAllBytes("inputfile");
            int filesOutput = 0;
            int startIndex = -1;
            int currentIndex = 0;
            for (;;)
            {
                int nextIndex = Array.IndexOf(fileBytes, (byte)'G', currentIndex);
                if (nextIndex == -1)
                {
                    // There are no more ASCII 'G's in the file.
                    break;
                }
                if (nextIndex + 4 >= fileBytes.Length)
                {
                    // There aren't enough characters left in the file for this
                    // to be an ASCII "GBIX" string.
                    break;
                }
                if (fileBytes[nextIndex+1] == (byte)'B' &&
                    fileBytes[nextIndex+2] == (byte)'I' &&
                    fileBytes[nextIndex+3] == (byte)'X')
                {
                    // Found ASCII "GBIX" at nextIndex. Output the previous
                    // complete file, if there is one.
                    if (startIndex != -1)
                    {
                        Write(filesOutput, fileBytes, startIndex, nextIndex - startIndex);
                    }
                    filesOutput += 1;
                    startIndex = nextIndex;
                }
                currentIndex = nextIndex + 1;
            }
            if (startIndex != -1)
            {
                WriteFile(filesOutput, fileBytes, startIndex, fileBytes.Length - startIndex);
            }
        }
    }
