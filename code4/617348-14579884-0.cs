        private void StockReceivesForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L && e.Control &&
                     e.Shift)
            {
                yourButton.PerformClick();
                e.Handled = true;
            }
        }
