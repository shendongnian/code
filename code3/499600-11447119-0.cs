        public Image ImageFromBytes(byte[] bytes)
        {
            using(var ms = new MemoryStream(bytes))
            {
              return Image.FromStream(ms);
            }
        }
