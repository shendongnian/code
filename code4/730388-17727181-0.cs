    public partial class Form2 : Form
    {
    private string _currentValue;
    
    //Property to get value from Form1
    public string CurrentValue
    {
    	get { return _currentValue; }
    	set { _currentValue = value; }
    }
    
    public Form2()
    {
    	InitializeComponent();
    	//set the dialog result to be as OK when button is clicked
    	button1.DialogResult = System.Windows.Forms.DialogResult.OK;
    }
    
    public string getSelectedValue()
    { 
    	return dataGridView1[<the field name you need to get>, dataGridView1.CurrentRow.Index].Value.ToString();
    }
    }
