    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var newButton = new Button { Text = "Click me", Dock = DockStyle.Top };
            newButton.Click += new EventHandler(newButton_Click);
            this.panel1.Controls.Add(newButton);
        }
        void newButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I was clicked");
            var button = sender as Button;
            button.Click -= new EventHandler(newButton_Click);
            this.panel1.Controls.Remove(button);
        }
    }
