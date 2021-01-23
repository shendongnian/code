    for (int i = 0; i < names.Count; i++)
            {
                rows[0] = names.ElementAt(i).Trim();
                rows[1] = versions.ElementAt(i).Trim();
                programsGrid.Rows.Insert(i, rows);
            }
