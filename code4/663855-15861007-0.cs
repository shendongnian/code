       List<string> names = new List<string>();
            int num = 1;
            foreach (var item in americanCulture.DateTimeFormat.MonthNames)
            {
                names.Add(string.Format("{0} - {1}", num++.ToString("D2"), item));
            }
            ddlMonth.Items.AddRange(names);
