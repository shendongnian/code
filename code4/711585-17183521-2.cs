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
    
        Form2 frm = new Form2(x); // pass variable to form2, if multiple values pass int array
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
    
    // Overloading of constructor
    public Form2(int X) // if multiple values pass int array
    {
        InitializeComponent();
        local_X = x;  // capture value from constructor in class variable.
    }
    
    private void Form2_Load(object sender, EventArgs e)
    {
       // no need to iterate here for now due to overloading value get passed during initialization.
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
       MessageBox.Show("Value of X is : " + local_X);  // display value if alert box.
    }
    
    }
