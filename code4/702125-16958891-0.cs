    DataGridView dgw = new DataGridView();
    TabPage tp = new TabPage();
    //data grid view
    dgw.AutoGenerateColumns = true; // <====== added this line
    dgw.Name = "dgv" + num;
    dgw.AutoSize = true;
    dgw.Dock = DockStyle.Fill;
    // ... some here not shown
    dgw.DataSource = dt; 
