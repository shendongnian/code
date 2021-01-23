     private void btnSave_Click(object sender, EventArgs e)
        {
            //get data back from the datagrid view
            //assuming my gridview is bound to ObservableCollection<User>
            var users= dataGridView1.DataSource as ObservableCollection<User>;
            foreach (var user in users)
            {
                //perform the save
            }
            
        }
