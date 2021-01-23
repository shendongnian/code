    private void txtAditionalBatch_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsDigit(e.KeyChar)) e.Handled = true;         //Just Digits
                if (e.KeyChar == (char)8) e.Handled = false;            //Allow Backspace
                if (e.KeyChar == (char)13) btnSearch_Click(sender, e);  //Allow Enter            
            }
