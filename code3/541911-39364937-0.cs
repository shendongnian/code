                    StringBuilder tableRtf = new StringBuilder();
                    tableRtf.Append(@"{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}");
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {   
                        tableRtf.Append(@"\trowd");
                        tableRtf.Append(@"\cellx2500" + "  " + ds.Tables[0].Rows[j]["caption"].ToString());
                        tableRtf.Append(@"\intbl\cell");
                        tableRtf.Append(@"\cellx10000\intbl\cel");
                        tableRtf.Append("   "+ ds2.Tables[0].Rows[k][j].ToString() + @"\intbl\clmrg\cell\row");
                        
                    }
                    tableRtf.Append(@"\pard");
                    tableRtf.Append(@"}");                    
                    richTextBox2.Rtf = tableRtf.ToString();
