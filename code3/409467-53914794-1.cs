    foreach (DataRow dr in datatable1.Rows)
        foreach (DataRow dr2 in datatable2.Rows)
        {
            if (dr.ItemArray.SequenceEqual(dr2.ItemArray))
            {
                MessageBox.Show("dr = dr2");
                //statement                                    
            }
            else
            {
                MessageBox.Show("dr != dr2");
                //statement
            }
        }
