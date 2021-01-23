    public partial class Form2 : Form
    {
    public string textBoxValue;
    public Form2()
    {
        InitializeComponent();
    }
    public Form2(string textBoxValue)
    {
        InitializeComponent();
        this.textBoxValue = textBoxValue;
    }
    private void Form2_Load(object sender, EventArgs e)
    {
        textBox2.Text = textBoxValue;
    }
