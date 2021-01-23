            int cnt = 0;
            foreach (string s in colsList)
            {
                if (table.Columns.Contains(s))
                {
                    table.Columns[s].SetOrdinal(cnt);
                    cnt++;
                }
            }
