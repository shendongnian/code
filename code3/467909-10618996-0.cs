      public partial class Form2 : Form
                {
                    public Form2()
                    {
                        InitializeComponent();
                    }
        
                    public bool checkBox1 { get; set; }
                    
                    private void Form2_Load(object sender, EventArgs e)
                    {
                        if (checkBox1)
                        {
                            label1.Text = "true";
                        }
                        else
                        {
                            label1.Text = "false";
                        }
                    }
                }
