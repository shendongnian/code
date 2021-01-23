        public List<DataRow> GenrePercent(string status, string genre)
        {
            List<DataRow> dataList = new List<DataRow>();
            var wordPattern = new Regex(@"\w+");
            DataRow[] rows = fbTab.Select(String.Format("Genre = '{0}'", genre.Replace("'", "''")));
            foreach (Match match in wordPattern.Matches(status))
                foreach (var item in rows)
                    if (item["Word"].ToString().ToLower() == match.ToString().ToLower())
                    {
                        dataList.Add(item);
                    }
            return dataList;
        }
