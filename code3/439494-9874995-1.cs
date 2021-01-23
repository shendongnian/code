        public static IEnumerable<string> Split(this Stream stream, string delimiter, StringSplitOptions options)
        {
            var buffer = new char[_bufffer_len];
            StringBuilder output = new StringBuilder();
            int read;
            using (var reader = new StreamReader(stream))
            {
                do
                {
                    read = reader.ReadBlock(buffer, 0, buffer.Length);
                    output.Append(buffer, 0, read);
                    var text = output.ToString();
                    int id = 0, total = 0;
                    while ((id = text.IndexOf(delimiter, id)) >= 0)
                    {
                        var line = text.Substring(total, id - total);
                        id += delimiter.Length;
                        if (options != StringSplitOptions.RemoveEmptyEntries || line != string.Empty)
                            yield return line;
                        total = id;
                    }
                    output.Remove(0, total);
                }
                while (read == buffer.Length);
            }
            if (options != StringSplitOptions.RemoveEmptyEntries || output.Length > 0)
                yield return output.ToString();
        }
