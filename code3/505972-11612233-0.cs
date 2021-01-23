    // In case if you're dealing with WinForms
    // For WPF solution could have similar approach
    
    public class DataGridForm : Form
    {
    	private DataGrid _grid;
    
    	public DataGridForm()
    	{
    		InitializeComponent();// <-- here _grid is instantiated		 
    	}
    
    	public void LoadData(object data)
    	{
    		// load data into grid
    		// I don't know, could be smt like
    		DataGridCell cell = _grid.Cells[0,0];
    		cell.Value = data; 
    	}
    }
    
    public class FormWithComboBox : Form
    {
    	private ComboBox _comboBox;
    
    	public DataGridForm DataGridForm { get; set; }// value is set by some externat user
    	
    	public FormWithComboBox()
    	{
    		InitializeComponent();// <-- here _grid is instantiated		 
    		// including handler for OnSelectedItemChanged event
    	}
    
    	private void _comboBox_OnSelectedItemChanged(object sender, EventArgs e)
    	{
    		DataGridForm.LoadData(_comboBox.SelectedItem);
    	}
    }
