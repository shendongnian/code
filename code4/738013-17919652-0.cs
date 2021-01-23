            //read file into memory
            byte[] docByteArray = File.ReadAllBytes(templateName);
            using (MemoryStream ms = new MemoryStream())
            {
                //write file to memory stream
                ms.Write(docByteArray, 0, docByteArray.Length);
                //
                ReplaceText(ms);
                //reset stream
                ms.Seek(0L, SeekOrigin.Begin);
                //save output
                using (FileStream outputStream = File.Create(docName))
                    ms.CopyTo(outputStream);
            }
