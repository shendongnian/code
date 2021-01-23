        public void HandleMycontent(byte[] content)
        {
            using (var stream = new System.IO.MemoryStream(content))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader))
                    {
                        //parse my csv here
                    }
                }
            }
        }
