        public static T LoadData<T>(Context context, string fileName)
        {
            Java.IO.File file = context.GetFileStreamPath(fileName);
            if (file.Exists())
            {
                Stream openStream = context.OpenFileInput(fileName);
                using (StreamReader reader = new StreamReader(openStream))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        var loadedObject = serializer.Deserialize(reader);
                        return (T)loadedObject;
                    }
                    catch (Exception ex)
                    {
                        // TODO Handle error
                        return default(T);
                    }
                }
            }
            else
            {
                throw new Java.IO.FileNotFoundException("Could not find file " + fileName);
            }
        }
