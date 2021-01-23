        public static bool SaveData<T>(Context context, string fileName, T data)
        {
            try
            {
                using (Stream stream = context.OpenFileOutput(fileName, FileCreationMode.Private))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(stream, data);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
