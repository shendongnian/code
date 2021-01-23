    public partial class Form2: Form
    {
    	public Form2()
    	{
    		InitializeComponent();
    	}
    
    	public DataRow[] dataRow;
    	private void Form2_Load(object sender, EventArgs e)
    	{
    		var select = dataRow[0];
    		lastNameTextBox.Text = select[1].ToString();
    		firstNameTextBox.Text = select[2].ToString();
    		middleNameTextBox.Text = select[3].ToString();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		MainForm m = this.Owner as MainForm;
    		var updated = dataRow[0];
    		updated[1] = lastNameTextBox.Text;
    		updated[2] = firstNameTextBox.Text;
    		updated[3] = middleNameTextBox.Text;
    		m.mainDataRow[0] = updated;
    		Close();
    	}
    }
    
