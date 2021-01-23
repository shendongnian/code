         /// <summary> Gets the body. </summary>
         /// <returns> The body. </returns>
         protected byte[] GetBytes()
         {
           byte[] bytes;
            using (var binaryReader = new BinaryReader(Request.InputStream))
            {
                bytes = binaryReader.ReadBytes(Request.ContentLength);
            }
             return bytes;
         }
