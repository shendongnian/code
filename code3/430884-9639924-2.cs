    public partial class Form1 : Form
    {
        // Create an instance of the button
        TextBox test = new TextBox();
        public Form1()
        {
            InitializeComponent();
            // Set button values
            test.Text = "Button";
            // Add the event handler
            test.KeyPress += new KeyPressEventHandler(this.KeyPressEvent);
            // Add the textbox to the form
            this.Controls.Add(test);
        }
        // Keypress event
        private void KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(test.Text);
        }
    }
