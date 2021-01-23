        public static string WriteValues(int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int index = start; index <= end; index++)
            {
                sb.Append(index).Append(",");
            }
            sb.Length -= 1;
            sb.Append("]");
            return sb.ToString();
        }
