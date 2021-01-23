    public partial class classMain : Form
    {
        // Move your list to a global scope in the classMain form.
        TextBox[] txtFldNames = new TextBox[15];
        
        public frmMain()
        {
            InitializeComponent();
        }
    
        private void frmMain_Load(object sender, EventArgs e)
        {
            int x = 155, y = 65, w = 300, h = 20;
    
            for (int i = 0; i < 15; i++)
            {
                y = y + 30;
                txtFldNames[i] = new TextBox();
                txtFldNames[i].Location = new System.Drawing.Point(x, y);
                txtFldNames[i].Size = new System.Drawing.Size(w, h);
                this.Controls.Add(txtFldNames[i]);
                txtFldNames[i].ReadOnly = true;
                txtFldNames[i].BackColor = Color.White;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //what to do here?
            
            // Now you can access the global array variable.
            for (int i = 0; i < 15; i++)
            {
                MessageBox.Show(txtFldNames[i].Text);
            }
        }
    }
