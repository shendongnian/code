        /// <summary>
        /// Reads file and puts it to ZIP stream
        /// </summary>
        private void ReadFileToZip(ZipOutputStream zipStream, string filename)
        {
            // Simple file reading :)
            using(FileStream fs = File.OpenRead(filename))
            {
                StreamUtils.Copy(fs, zipStream, new byte[4096]);
            }
        }
