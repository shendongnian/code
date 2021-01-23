    public class TabTextBox : TextBox
    {
    
        public bool ready_to_leave = false;
    
        protected override void OnEnter(EventArgs e)
        {
            this.SelectionStart = 0; // this.Text.IndexOf(".") + 1;
            this.SelectionLength = this.Text.IndexOf(".");
        }  
    
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab && !ready_to_leave)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }
    
        protected override void OnLeave(EventArgs e)
        {
            ready_to_leave = false;
            base.OnLeave(e);
        }
    
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (ready_to_leave)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab && !ready_to_leave)
            {
                this.SelectionStart = this.Text.IndexOf(".") + 1;
                this.SelectionLength = 2;
                ready_to_leave = true;
                e.Handled = true;
            }
            else
            {
    
                base.OnKeyDown(e);
            }
        }
    
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (this.SelectionStart - 1 < this.Text.IndexOf("."))
                    ready_to_leave = false;
            }
            base.OnKeyUp(e);
        }
    } 
