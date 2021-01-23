     protected override void OnKeyUp(KeyEventArgs e)
        {       
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                e.KeyCode == Keys.Decimal)
            {
                 e.Handled = false;
                 base.OnKeyUp(e);
            }
            else
            {
                 e.Handled= true;
            }       
            
        }
