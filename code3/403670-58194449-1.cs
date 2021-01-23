                using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDailog1.FileName)))
            {
                br.BaseStream.Seek(0x4D, SeekOrigin.Begin); //Put the beginning of a .dat file here. I put 0x4D, because it's the generic start of a file.
                gameCode = Encoding.UTF8.GetString(br.ReadBytes(512)); //Or whatever string you want
            }
            br.Close();
