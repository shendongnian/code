    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
        } 
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; 
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filex = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filex.Length > 0)
            { 
                    pictureBox1.ImageLocation = filex[0]; 
                
            }
        }
    
    }
