            String parsedStream;
            var parsedPage = await WebDataCache.GetAsync(new Uri(String.Format("http://bash.im")));
            var buffer = await FileIO.ReadBufferAsync(parsedPage);
            using (var dr = DataReader.FromBuffer(buffer))
            {
                var bytes1251 = new Byte[buffer.Length];
                dr.ReadBytes(bytes1251);
                parsedStream = Encoding.GetEncoding("Windows-1251").GetString(bytes1251, 0, bytes1251.Length);
            }
