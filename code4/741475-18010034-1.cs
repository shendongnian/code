                DataTable dt = new DataTable();
                DataTable dtFiltered = new DataTable();
                if (Cache["PoliceData"] != null)
                    {
                        dt = (DataTable)Cache["PoliceData"];
                        if (DDL1.SelectedValue != "Select" && !string.IsNullOrEmpty(DDL1.SelectedValue))
                            dt.DefaultView.RowFilter = "[policeID] <> " + DDL1.SelectedValue;
                        else
                            dt.DefaultView.RowFilter = "[policeID] <> " + 0;
                        dtFiltered = dt.DefaultView.ToTable();
                    }
