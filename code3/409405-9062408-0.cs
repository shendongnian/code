     DataTable dt = new DataTable();
      dt.Columns.Add("Age", typeof(int));
      dt.Columns.Add("Name");
      dt.Rows.Add(new DataRow(0," ");
      dataGridView1.AllowUserToAddRows = false;
      dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
      dataGridView1.DataSource = dt;
      dataGridView1.AllowUserToAddRows=false;
