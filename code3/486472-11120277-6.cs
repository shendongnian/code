    class MyDataGridView : DataGridView
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter) && (this.EditingControl != null))
            {
                //new behaviour for Enter
                TextBox tb = (TextBox)EditingControl;
                int pos = tb.SelectionStart;
                tb.Text = tb.Text.Remove(pos, tb.SelectionLength);
                tb.Text = tb.Text.Insert(pos, Environment.NewLine);
                tb.SelectionStart = pos + Environment.NewLine.Length;
                tb.ScrollToCaret();
                //and do nothing else
                return true;
            }
            else if ((keyData == Keys.Up) && (this.EditingControl != null))
            {
                //programmatically move caret up
                //(look at related question to see how)
                return true;
            }
            else if ((keyData == Keys.Down) && (this.EditingControl != null))
            {
                //programmatically move caret down
                //(look at related question to see how)
                return true;
            }
            //for the rest of the keys, proceed as normal
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
