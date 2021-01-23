    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    Label lbl = new Label();
                    lbl.Text = "Testing";
                    lbl.Location = new Point(125, 125);
                    this.Controls.Add(lbl);
                }
            }
        }
