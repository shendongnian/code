    private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.FormOwnerClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }
