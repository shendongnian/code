       class CustomPrintPreviewDialog : System.Windows.Forms.PrintPreviewDialog
        {
            public CustomPrintPreviewDialog()
                : base()
     
            {
                if(this.Controls.ContainsKey("toolstrip1"))
                {
     
                    ToolStrip tStrip1 = (ToolStrip)this.Controls["toolstrip1"];
                    ToolStripButton button1 = new ToolStripButton();
                    button1.Text = "Save";
                    button1.Click += new EventHandler(SaveDocument);
                    button1.Visible = true;
                    tStrip1.Items.Add(button1);
                }
            }
     
            protected void SaveDocument(object sender, EventArgs e)
            {
                // code for save the document
                MessageBox.Show("OK");
            }
        }
 
