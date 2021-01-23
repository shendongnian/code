        void WriteToStreamInUnknownStatus(BinaryWriter binaryWriter)
        {
            var myStream = new MemoryStream();
            try
            {
                binaryWriter.Write(myStream.ToArray());
            }
            catch
            { }
        }
