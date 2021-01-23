    public Form1()
    {
    	InitializeComponent();
    	BindGrid();
    }
    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	BindGrid();
    }
    private void BindGrid()
    {
    	CheckedListBox  checkedListBox1=new CheckedListBox();
    	var sb=new StringBuilder();
    	foreach (ListBox item in checkedListBox1.SelectedItems)
    	{
    		sb.Append("'"+item.Text+"',");
    	}
    	if(sb.Length>0)
    		sb.Length--;
    		
    	string strSQL;
    	if(sb.Length>0)
    	{
    		strSQL = "select mnthname as 'Month',Description,Amount from monthfee where mnthname IN(" + sb.ToString()+ ")";
    	}
    	else
    	{
    		strSQL = "select mnthname as 'Month',Description,Amount from monthfee";
    	}
    	string strCon = "Data Source=.;Initial Catalog=SAHS;User Id=sa;Password=faculty";
    	SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strCon);
    	SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
    
    	// Populate a new data table and bind it to the BindingSource.
    	DataTable table = new DataTable();
    	table.Locale = System.Globalization.CultureInfo.InvariantCulture;
    	dataAdapter.Fill(table);
    	bindingSource1.DataSource = table;
    
    	// Resize the DataGridView columns to fit the newly loaded content.
    
    	dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
    	// you can make it grid readonly.
    	dataGridView1.ReadOnly = false;
    	// finally bind the data to the grid
    	dataGridView1.DataSource = bindingSource1;
    }
