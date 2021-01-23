                foreach (DataRow dRow in dt1.Rows)
                {
                    a = dRow[0].ToString();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        b = dt2.Rows[i][0].ToString();
                        if (hcontroller.GetScore(a, b) >= 90.00)
                        {
                            c = dt2.Rows[i][1].ToString();
                            match = true;
                            break;
                        }
                        else
                        {
                            match = false;
                            continue;
                        }
                        
                    }
                    if (match)
                    {
                        dt.Rows.Add(a, b, c);
                    }
                    else
                    {
                        dt.Rows.Add(a, "No close matches found!", "");
                    }
                }
