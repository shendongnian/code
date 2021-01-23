     /// <summary>
        /// Binds the Grid view.
        /// </summary>
        private void BindGridView()
        {
            //Creating the columns. 
            //The gridview will know how to sort Items by the type specified in the second argment
            DataTable dt = new DataTable();
            dt.Columns.Add("Id",typeof(int));
            dt.Columns.Add("Price",typeof(int));
            dt.Columns.Add("IsActive",typeof(bool));
            //Creating some random data
            //Replace this with your actual data...
            Random rnd = new Random(1);
            for (int i = 0; i < 100; i++)
            {
                int Id = i+1;
                int Price = Id%2 == 0? 500-Id*2:350+Id*3;
                bool isActive = (Id%5) !=0;
                DataRow row =  dt.NewRow();
                row["Id"] =Id ;
                row["Price"] = rnd.Next(1000) ;
                row["IsActive"] = isActive;
                dt.Rows.Add(row);                
            }
            this.dataGridView1.DataSource = dt;
            //making sure all columns are sortable
            foreach (DataGridViewColumn col in this.dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }            
            
            
        }
  
