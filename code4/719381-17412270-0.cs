    public class FrmTest : Form
    {
    
    	public FrmTest()
    	{
    		InitializeComponent();
    
    		this.DataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
    		this.DataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    		this.DataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    	}
    
    	private void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
    	{
    		if (this.CheckBox1.Checked) {
    			this.DataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
    		} else {
    			this.DataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    		}
    		this.DataGridView1.Refresh();
    	}
    }
