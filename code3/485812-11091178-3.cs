    DataTable tblFiltered = gridToTable.AsEnumerable()
                           .Where(r => r.Field<int>("ID").ToString().Contains(txtSearchID.Text) 
                                    || r.Field<string>("TITLE").Contains(txtSearchTitle.Text)
                                    || r.Field<string>("Company").Contains(txtSearchCompany.Text)
                                    || r.Field<string>("UserName").Contains(txtSearchUserName.Text))
                           .CopyToDataTable();
