    public partial class Form1 : Form
    {
        List<TextBox> name = new List<TextBox>();
        int length = 5;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < length; i++)
            {
                name.Add(new TextBox() { Location = new System.Drawing.Point(137, 158 + i * 25), 
                                         Size = new System.Drawing.Size(156, 20) });
                StartTab.Controls.Add(name[i]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < length; i++)
            {
                StartTab.Controls.Add(new Label() {Location = new System.Drawing.Point(name[i].Location.X + name[i].Width + 20,
                                                   name[i].Location.Y), 
                                                   Text = name[i].Text, 
                                                   AutoSize = true });
            }
        }
    }
