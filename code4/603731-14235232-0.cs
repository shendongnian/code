    foreach (TableCell cell in e.Row.Cells) {
                        if (cell.Text != "-1" && cell.Text != "Cotton Arrival") {
                            
                            char[] c = new char[7];
                            c = cell.Text.ToCharArray();
    
                            string datee = c[0].ToString()+c[1].ToString() ;
                            string monthh = c[2].ToString() + c[3].ToString();
                            string yearr = c[4].ToString() + c[5].ToString() + c[6].ToString() + c[7].ToString();
    
                            DateTime dtime = new DateTime(Convert.ToInt32(yearr),Convert.ToInt32(monthh),Convert.ToInt32(datee));
    
                            string day = dtime.DayOfWeek.ToString() ;
    
                            if (day.ToLower() == "monday") 
                            {
                                GridView1.Columns[count].ItemStyle.CssClass = "monday";
                                GridView2.Columns[count].ItemStyle.CssClass = "monday";
                                GridView3.Columns[count].ItemStyle.CssClass = "monday";
                                GridView4.Columns[count].ItemStyle.CssClass = "monday";
                                break;
                            }
                            count ++;
                        }
                    }
