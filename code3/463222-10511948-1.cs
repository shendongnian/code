    DataTable dt = new DataTable();
    dt.Columns.Add("ActorID", typeof(int));
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("BirthDate", typeof(DateTime));
    
    
    dt.Rows.Add(1, "Will Smith", new DateTime(1968,9,25));
    dt.Rows.Add(2, "Bruce Willis", new DateTime(1955,3,19));
    dt.Rows.Add(3, "Jim Carrey", new DateTime(1962, 1, 17));
    dt.Rows.Add(18, "Nicole Kidman", new DateTime(1967,6,20));
    	
    ComboBox cb = new ComboBox();
    cb.DropDownStyle = ComboBoxStyle.DropDownList;
    cb.Location = new Point(20, 100);
    cb.Width = 100;
    cb.DisplayMember = "Name";  // *****
    cb.ValueMember = "ActorID"; // ***** The important part
    cb.DataSource = dt;
    
    Button btn = new Button();
    btn.Text = "Show ID";
    btn.Location = new Point(10, 140);
    btn.Click += (sender, e) =>
        {
            MessageBox.Show(cb.SelectedValue.ToString()); // **** The other important part.
        };
    
    Form f = new Form();
    f.Controls.Add(cb);
    f.Controls.Add(btn);
        
    f.ShowDialog();
