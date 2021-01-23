        public static String ReadUntil(this StreamReader streamReader, String delimiter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                stringBuilder.Append(value: (Char) streamReader.Read());
                if (stringBuilder.ToString().EndsWith(value: delimiter))
                {
                    stringBuilder.Remove(stringBuilder.Length - delimiter.Length, delimiter.Length);
                    break;
                }
            }
            return stringBuilder.ToString();
        }
