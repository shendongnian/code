    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace rich_RichtextboxDragDrop
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                AllowDrop = true;
                this.richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
                this.richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
            }
            void richTextBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
            {
    
                if ((e.Data.GetDataPresent(DataFormats.FileDrop)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            void richTextBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
            {
                Image img = default(Image);
                img = Image.FromFile(((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString());
                Clipboard.SetImage(img);
             
                this.richTextBox1.SelectionStart = 0;
                this.richTextBox1.Paste();
            }
        }
    
    }
