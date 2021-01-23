            foreach (set.row officeJoin in officeJoinMeta)
            {
                foreach (set.somethingRow confRow in myData.something.Rows)
                {
                    string dep = confRow["columnName"].ToString();
                    if (dep.IndexOf(",") >= 0)
                    {
                        depts.AddRange(dep.Split(','));
                    }
                    else
                    {
                        depts.Add(dep);
                    }
                }
            }
