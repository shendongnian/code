                    if ((bool)sRow.Cells[1].Value)
                    {
                        Worked = "X";
                    }
                    else if ((bool)sRow.Cells[2].Value)
                    {
                        Vacation = "X";
                    }
                    else if (sRow.Cells[3].Value)
                    {
                        Sick = "X";
                    }
                    else if ((bool)sRow.Cells[4].Value)
                    {
                        Holiday = "X";
                    }
