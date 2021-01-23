      I calculate the issued date avoid your holiday from your table 'tblHolidayMaster' only.
                        int addDay = -14;
                        DateTime dtInputDay = System.DateTime.Now;//Your input day
                        DateTime dtResultDate = new DateTime();
                        dtResultDate = dtInputDay.AddDays(addDay);
                        bool result = false;
                        string strExpression;
                        DataView haveHoliday;
                        while (!result)
                        {
                            strExpression = "Date >='" + Convert.ToDateTime(dtResultDate.ToString("yyyy/MM/dd")) + "' and Date <='" + Convert.ToDateTime(dtInputDay.ToString("yyyy/MM/dd")) + "'";
                            haveHoliday = new DataView(tblHolidayMaster);
                            haveHoliday.RowFilter = strExpression;
                            if (haveHoliday.Count == 0)
                                result = true;
                            else
                            {
                                addDay = -(haveHoliday.Count);
                                dtInputDay = dtResultDate.AddDays(-1);
                                dtResultDate = dtResultDate.AddDays(addDay);
                            }
                        }
		Your issued date is dtResultDate 
