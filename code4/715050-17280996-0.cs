        public static string ConcatList(List<bool> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (bool b in list)
            {
                builder.Append(b == true ? "1" : "0";
            }
            return builder.ToString();
        }
