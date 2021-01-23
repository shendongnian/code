        public void YourWCFMethodHere(byte[] exception)
        {
            using (MemoryStream ms = new MemoryStream(exception, false))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Exception ex = (Exception)bf.Deserialize(ms);
                // Do something with the exception here
            }
        }
