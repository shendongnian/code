    public partial class Form1 : Form
    {
    
    public int X;
    
    public Form1()
    {
        InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        X = 100;
    
        Form2 frm = new Form2();
        frm.Show();
       
        this.Hide();
    }  
    }
    
    
    
    public partial class Form2 : Form
    {
    
    int local_X = 0;
    
    public Form2()
    {
        InitializeComponent();
    }
    
    private void Form2_Load(object sender, EventArgs e)
    {
       foreach(Form f in System.Windows.Forms.Application.OpenForms)
       {
          if(typeof(f) == typeof(Form1))
    	{
    	   local_X = f.X;   // access value here and set in local variable
    	}
       }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
       MessageBox.Show("Value of X is : " + local_X); // Show alert for value of variable on button click
    }
    
    }
