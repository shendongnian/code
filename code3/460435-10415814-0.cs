    DataTable dt = new DataTable("Test");
                dt.Columns.Add("ID") ;
                dt.Columns.Add("StudentID");
                dt.Columns.Add("StudentName");
                            
                object[] rowVals = new object[3];
                rowVals[0] = "1";
                rowVals[1] = "ST-1";
                rowVals[2] = "Kunal Uppal";
                
                dt.Rows.Add(rowVals);
                string studentID = "ST-1"; //this can come from a textbox.Text property
                DataRow[] collection= dt.Select("StudentID=" + "'" + studentID + "'");
                string studentName = Convert.ToString(collection[0]["StudentName"]);
