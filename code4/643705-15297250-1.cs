    public static Collection<object> ReatFile(string fileName){
                //I have to read the file which I have wrote to an byte array            
                byte[] file;
                using (var stream = new FileStream(Server.MapPath("~/Files/" + fileName), FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                    }
                }
                //And now is what I have to do with the byte array of file is to convert it back to object which I have wrote it into a file
                //I am using MemoryStream to convert byte array back to the original object.
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(file, 0, file.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                Object obj = (Object)binForm.Deserialize(memStream);
                Collection<object> list = (Collection<object>)obj;
                return list;
    }
