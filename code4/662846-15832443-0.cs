           public void tools23(Object sender, KeyEventArgs e)
            {
                if (e.KeyValue == 13)
                {
                    ToolStripTextBox t = (ToolStripTextBox)sender;
                    MessageBox.Show("the text entered in the toolstriptextbox is " + t.Text);
                }
            }
