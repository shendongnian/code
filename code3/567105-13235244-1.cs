        public class ControlsInteraction
        {
            public class WithDDL
            {
                public class GetSelVal
                {
                    public string AsString(DropDownList DDLToCollectValusFrom)
                    {
                        return DDLToCollectValusFrom.SelectedValue;
                    }
                    public int AsInt(DropDownList DDLToCollectValusFrom)
                    { 
                        if(DDLToCollectValusFrom.SelectedValue != null)
                        return Convert.ToInt32(DDLToCollectValusFrom.SelectedValue);
                        return 666;
                    }
                }
                public List<string> GetListItems_Values(DropDownList DDLToCollectValusFrom)
                {
                    List<string> LST_DDLValues = new List<string>();
                    foreach (ListItem item in DDLToCollectValusFrom.Items)
                    {
                        LST_DDLValues.Add(item.Value);
                    }
                    return LST_DDLValues;
                }
                public List<string> GetListItems_Text(DropDownList DDLToCollectTextFrom)
                {
                    List<string> LST_DDLTEXT = new List<string>();
                    foreach (ListItem item in DDLToCollectTextFrom.Items)
                    {
                        LST_DDLTEXT.Add(item.Text);
                    }
                    return LST_DDLTEXT;
                }
            }
            public static class WithPlcHldr
            {
                public static void AddCtrl(PlaceHolder PlcHldrID, Control CntrID)
                {
                    PlcHldrID.Controls.Add(CntrID);
                }
            }
            public class WithTable
            {
                public class Design
                {
                    public string RowsBGColorAlternate(int RowCounter, bool AddWithStyleAsStandAlone = false)
                    {
                        string BgCol = ""; bool bgclaltrnator;
                        if (RowCounter > 0)
                        {
                            RowCounter++;
                            bgclaltrnator = (RowCounter % 2) == 0;
                            if (bgclaltrnator)
                                BgCol = "#70878F";
                            else BgCol = "#E6E6B8";
                        }
                        if (AddWithStyleAsStandAlone)
                        return string.Format("style=\"background-color:{0};\"", BgCol);
                        return string.Format("background-color:{0};", BgCol);
                    }
                }
                public class ExtractData
                {
                    public string ColumnValueFromCurrRow(DataRow DtRow, string RequestedColName)
                   {
                        return "";
                    }
                    public string DataRows_ColumnToString(DataRow Data_RowToActOn, string keyColName)
                    {
                        var tmp = Data_RowToActOn[keyColName];
                        return Data_RowToActOn[keyColName].ToString();
                    }
                    public int DataRowToInt(DataRow Data_RowToActOn, string keyColName)
                    {
                        string tmp = Data_RowToActOn[keyColName].ToString();
                        return Convert.ToInt32(tmp);
                    }
                    public bool CurrColumnIs(DataColumn Data_RowToQuestion, string ColumnName)
                    {
                        string tmp = Data_RowToQuestion.ToString();
                        return tmp == ColumnName;
                    }
                    public bool CurrRowIs(DataRow Data_RowToQuestion, string RowName, int CurrIndex)
                    {
                        string ColsName = Data_RowToQuestion.Table.Columns[CurrIndex].ToString();
                        return ColsName == RowName;
                        //this is curent value - by index 
                        //string currentColumn = Data_RowToQuestion.ItemArray[CurrIndex].ToString();
                        
                    }
                }
          
            }
        }
