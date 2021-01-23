        public List<DataRow> QualifyPercent(string status, string selectQualifier)
        {
            List<DataRow> dataList = new List<DataRow>();
            var wordPattern = new Regex(@"\w+");
            DataRow[] rows = fbTab.Select(selectQualifier);
            foreach (Match match in wordPattern.Matches(status))
                foreach (var item in rows)
                    if (item["Word"].ToString().ToLower() == match.ToString().ToLower())
                    {
                        dataList.Add(item);
                    }
            return dataList;
        }
