        public string AddStream(Stream stream, string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return null;
            }
            string fileExt = Path.GetExtension(filename).ToLower();
            string fileName = Guid.NewGuid().ToString();
            var strLen = Convert.ToInt32(stream.Length);
            var strArr = new byte[strLen];
            stream.Read(strArr, 0, strLen);
            //you will need to change the type of streams acccordingly
            this.streams.Add(filename,strArr); 
        }
