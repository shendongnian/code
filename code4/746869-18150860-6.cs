    private void btnSearch_Click(object sender, EventArgs e)
    {
        int clientNo = 0;
        var myResults = GetData(clientNo);
        if (int.TryParse(txtInput.Text, clientNo))
        {
            if ((myResults.Count == 1))
            {
                //Execute Code
            }
            else
            {
                MessageBox.Show("NAH");
            }
        }
        else
        {
            MessageBox.Show("NAH");
        }
    }
