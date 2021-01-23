      public partial class Form1 : Form
    {
        Form2 formChild;
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
       
        void Form1_Load(object sender, EventArgs e)
        {
           formChild = new Form2();
           formChild.MdiParent = this;
           formChild.Show();            
        }
        
       private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            rtb.Copy(); // Copy from RichTextBox in Form1
        }
        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            formChild.PasteText(); // Method in Form2 to Paste to the RichTextBox in Form2
        }
