     IEnumerable<DataRow> query =( from p in orginalList.AsEnumerable()
                                        where p.Field<long>("Category") == 2
                                        select p).ToList();
                            DataTable boundTable = query.CopyToDataTable<DataRow>();
    
                            dataGridView1.AutoGenerateColumns = false;
    
                            dataGridView1.DataSource = boundTable;
