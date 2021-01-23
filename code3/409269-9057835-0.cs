     using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(1);
                }
                stream.Flush();
                byte[] bytes = stream.GetBuffer();
                //use it
            }
