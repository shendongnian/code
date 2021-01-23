    ...
    using System.IO;
    ...
    
    public partial class Form1 : Form
    {
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();
        public string contents = string.Empty;
    	
        //string to hold file location
    	string currentFileLoc;
    	
    	
        public Form1()
        {
            InitializeComponent();
            this.Text = "Untitled";
        }
    
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != contents)
            {
                DialogResult dr = MessageBox.Show("Do You want to save the changes made to " + this.Text, "Save", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    sfd.Title = "Save";
                    if (SaveFile() == 0)
                        return;
                    else
                    {
                        richTextBox1.Text = "";
                        this.Text = "Untitled";
                    }
                    contents = "";
                }
                else if (dr == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    this.Text = "Untitled";
                    contents = "";
                }
                else
                {
                    richTextBox1.Focus();
                }
            }
            else
            {
                this.Text = "Untitled";
                richTextBox1.Text = "";
                contents = "";
            }
    
        }
        private int SaveFile()
        {
            sfd.Filter = "Text Documents|*.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                richTextBox1.Focus();
                return 0;
            }
            else
            {
                contents = richTextBox1.Text;
                if (this.Text == "Untitled")
                    richTextBox1.SaveFile(sfd.FileName,RichTextBoxStreamType.PlainText);
                else
                {
                    sfd.FileName = this.Text;
                    richTextBox1.SaveFile(sfd.FileName,RichTextBoxStreamType.PlainText);
                }
                this.Text = sfd.FileName;
    			//
    			currentFileLoc = sfd.FileName;
                return 1;
            }
    
    
        }
        private void OpenFile()
        {
            ofd.Filter = "Text Documents|*.txt";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                richTextBox1.Focus();
            else
            {
                richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                this.Text = ofd.FileName;
                contents = richTextBox1.Text;
            }
    		
    		currentFileLoc = ofd.FileName;
            this.Text = currentFileLoc;
        }
    
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != contents)
            {
                DialogResult dr = MessageBox.Show("Do You want to save the changes made to " + this.Text, "Save", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    SaveFile();
                    OpenFile();
                }
                else if (dr == DialogResult.No)
                {
                    OpenFile();
                }
                else
                {
                    richTextBox1.Focus();
                }
            }
            else
                OpenFile();
        }
    
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();            
        }
    	
    	private void SaveAs()
        {
            if (currentFileLoc != null)
            {
                using (StreamWriter writer = new StreamWriter(currentFileLoc))
                {
                    writer.WriteLine(richTextBox1.Text);
                }
            }
    
            else
              saveFile();
         }
     }
