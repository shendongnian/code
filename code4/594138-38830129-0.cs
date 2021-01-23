        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _sendMessage.PerformClick();
            } 
        }       
