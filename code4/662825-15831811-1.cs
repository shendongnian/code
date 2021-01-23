    public partial class frmMain : Form
    {
    	private List<Person> Persons = new List<Person>();
     
    	public frmMain()
    	{
    		InitializeComponent();
    
    		Person Joe = new Person("Sam", "Smith", "12.05.1992");
    		Persons.Add(Joe);
    
    		textBox1.Text = Persons[0].Forename;
    		textBox2.Text = Persons[0].Surname;
    		textBox3.Text = Persons[0].DateOfBirth;
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		MessageBox.Show(Persons[0].ToString()); // before change
    		Persons[0].Forename = textBox1.Text;
    		MessageBox.Show(Persons[0].ToString()); // after change
    	}
    }
