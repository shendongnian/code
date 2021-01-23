    public partial class MainForm : Form
    {
    	public MainForm()
    	{
    		InitializeComponent();
    	}
    
    	public BindingSource bs = new BindingSource();
    	public DataRow[] mainDataRow;
    	private DataTable employee = new DataTable();
    
    	private void MainForm_Load(object sender, EventArgs e)
    	{
    		employee.Columns.Add("Id");
    		employee.Columns.Add("LastName");
    		employee.Columns.Add("FirstName");
    		employee.Columns.Add("MiddleName");
    
    		object[] emp1 = { "1", "Some1a", "Some1b", "Some1c" };
    		object[] emp2 = { "2", "Some2a", "Some2b", "Some2c" };
    		object[] emp3 = { "3", "Some3a", "Some3b", "Some3c" };
    		object[] emp4 = { "4", "Some4a", "Some4b", "Some4c" };
    		employee.Rows.Add(emp1);
    		employee.Rows.Add(emp2);
    		employee.Rows.Add(emp3);
    		employee.Rows.Add(emp4);
    
    		bs.DataSource = employee;
    		dataGridView1.DataSource = bs;
    
    	}
    
    	private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    	{
    		//Convert the current selected row in the DataGridView to a DataRow
    		DataRowView currentDataRowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
    		mainDataRow = employee.Select("Id='"+ currentDataRowView[0].ToString() + "'"); //get the primary key id
    		using (var f = new Form2{ dataRow = mainDataRow, Owner = this })
    		{
    			f.ShowDialog();        
    		}
    	}
    }
