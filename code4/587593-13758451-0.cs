    private bool inputToLabel = true;
    private StringBuilder cardData = new StringBuilder();
    private void CreditCardProcessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputToLabel)
                return;
            if (e.KeyChar == '\r')
            {
                MessageBox.Show(cardData.ToString()); // Call your method here.
            }
            else
            {
                cardData.Append(e.KeyChar);
                //label13.Text = label13.Text + e.KeyChar;
            }
            e.Handled = true;
        }
