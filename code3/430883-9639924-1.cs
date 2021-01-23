    public partial class Form1 : Form
    {
        // Create an instance of the button
        Button test = new Button(); 
        public Form1()
        {
            InitializeComponent();
            // Set button values
            test.Text = "Button";
            // Add the event handler
            test.Click += new EventHandler(this.ClickEvent);
            // Add the button to the form
            this.Controls.Add(test);
        }
        // Click event to handle the button click event
        public void ClickEvent(Object sender, EventArgs e )
        {
            MessageBox.Show("Button click");
        }
    }
