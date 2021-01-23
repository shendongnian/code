            ProgressBar _Bar = new ProgressBar();
            DataView _View = new DataView();
            _View.Table = datatable;
            _View.RowStateFilter = DataViewRowState.CurrentRows;
            _Bar.Minimum = 0;
            _Bar.Maximum = _View.ToTable().Rows.Count;
            foreach (DataRow datarow in _View.ToTable().Rows)
            {
                // Define the list items    
                ListViewItem lvi = new ListViewItem(datarow["Row1"].ToString());
                lvi.SubItems.Add(datarow["Row2"].ToString());
                lvi.SubItems.Add(datarow["Row3"].ToString());
                lvi.SubItems.Add(datarow["Row4"].ToString());
                lvi.SubItems.Add(datarow["Row5"].ToString());
                lvi.SubItems.Add(datarow["Row6"].ToString());
                lvi.SubItems.Add(datarow["Row7"].ToString());
                // Add the list items to the ListView    
                listView4.Items.Add(lvi); 
                _Bar.PerformStep();
            }
