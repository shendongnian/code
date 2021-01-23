        [Test]
        public void Test()
        {
            var list = new List<string> {"String1", "String2", "String3"};
            string values = ArrayToString(list);
            string sql = string.Format("SELECT Column1 FROM Table1 WHERE Column1 IN ( {0} )", values);
        }
        private static string ArrayToString(IEnumerable<string> array)
        {
            var result = new StringBuilder();
            foreach (string element in array)
            {
                if (result.Length > 0)
                {
                    result.Append(", ");
                }
                result.Append("'");
                result.Append(element);
                result.Append("'");
            }
            return result.ToString();
        }
