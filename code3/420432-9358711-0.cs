        private List<string[]> ParseText(string text)
        {
            string[] lines = text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<string[]> list = new List<string[]>();
            foreach (var item in lines)
            {
                list.Add(item.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            }
            return list;
        }
