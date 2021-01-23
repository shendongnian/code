    public DateTime GetNextRepaymentDate(DateTime BaseDate, int instalmentCount, PaymentCalculation calc)
                {
                    DateTime dueDate = new DateTime();
        
                    switch (calc.Interval)
                    {
                        case DateInterval.Month:
        
                            dueDate = BaseDate.AddMonths((instalmentCount) * calc.Number);
        
                            if (!string.IsNullOrEmpty(calc.OtherCriteria))
                            {
                                if (calc.OtherCriteria == "Last")
                                {
                                    int lastDay = DateTime.DaysInMonth(dueDate.Year, dueDate.Month);
                                    dueDate = Convert.ToDateTime(string.Format("{0}/{1}/{2}", lastDay, dueDate.Month, dueDate.Year));
                                }
                                else
                                {
                                    int fixedDate = Convert.ToInt32(calc.OtherCriteria);
        
                                    if (dueDate.Day != fixedDate)
                                    {
                                        if (dueDate.Day > fixedDate)
                                        {
                                            while (dueDate.Day != fixedDate)
                                            {
                                                dueDate = dueDate.AddDays(-1);
                                            }
                                        }
                                        else
                                        {
                                            while (dueDate.Day != fixedDate)
                                            {
                                                dueDate = dueDate.AddDays(1);
                                            }
                                        }
                                    }
                                }
                            }
        
                            break;
        
                        case DateInterval.WeekOfYear:
        
                            dueDate = BaseDate.AddDays((instalmentCount) * (calc.Number * 7));
        
                            if (calc.FixedDay != null)
                            {
                                while (dueDate.DayOfWeek != calc.FixedDay)
                                {
                                    dueDate = dueDate.AddDays(-1);
                                }
                            }
        
                            break;
                    }
        
                    while (!PaymentIsAllowedOnDate(dueDate) == true)
                    {
                        dueDate = dueDate.AddDays(-1);
                    }
        
                    return dueDate;
                }
