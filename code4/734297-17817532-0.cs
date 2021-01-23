     foreach (CAR c in A)
                {
                    bool blnadded = false;
                    if (B.Count == 0) B.Add(c);
                    else    
                    foreach (CAR d in B)
                    {
                        if (d.Name==c.Name && d.EngineType==c.EngineType)
                            for (int i=0; i<d.Months.Count;i++)
                          d.Months[i]=(Convert.ToInt32(d.Months[i])+Convert.ToInt32(c.Months[i])).ToString();
                        blnadded = true;
                    }
                    if (blnadded==false)
                        B.Add(c);
                }
