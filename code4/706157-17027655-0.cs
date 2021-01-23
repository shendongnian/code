    public partial class Form1 : Form
    {
        private Label[] Labels;
        public Form1()
        {
            InitializeComponent();
            Labels = new Label[] { label1, label2, label3, label4, label5 };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>(); // for demonstration purposes
            // determine which Labels are currently visible in the scrolled panel:
            Rectangle rectPanel = panel1.RectangleToScreen(panel1.ClientRectangle);
            for(int i = 0; i < Labels.Length; i++)
            {
                Rectangle rectLabel = Labels[i].RectangleToScreen(Labels[i].ClientRectangle);
                if (rectLabel.IntersectsWith(rectPanel))
                {
                    // ... do something with "i" ...
                    names.Add(Labels[i].Name); // for demonstration purposes
                }
            }
            listBox1.DataSource = null; // for demonstration purposes
            listBox1.DataSource = names; // for demonstration purposes
        }
    }
