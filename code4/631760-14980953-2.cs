    public partial class Form1 : Form
    {
    public string textBoxValue;
    public Form1()
    {
        InitializeComponent();
    }
    public Form1(string textBoxValue)
    {
        InitializeComponent();
        this.textBoxValue = textBoxValue;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
         textBox1.Text = textBoxValue;
    }
