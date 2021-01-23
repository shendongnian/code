        private void GetValuesGroupedBy(List<Dictionary<string, object>> list, List<string> groupbyNames, List<string> summableNames)
        {
            // build the groupby string
            StringBuilder groupBySB = new StringBuilder();
            groupBySB.Append("new ( ");
            bool useComma = false;
            foreach (var name in groupbyNames)
            {
                if (useComma)
                    groupBySB.Append(", ");
                else
                    useComma = true;
                groupBySB.Append("it[\"");
                groupBySB.Append(name);
                groupBySB.Append("\"]");
                groupBySB.Append(" as ");
                groupBySB.Append(name);
            }
            groupBySB.Append(" )");
            var groupby = list.GroupBy(groupBySB.ToString(), "it");
        }
