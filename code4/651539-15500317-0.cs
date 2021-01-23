    private void dgvComp_KeyPress(object sender, KeyPressEventArgs e)
    {
        switch (e.KeyChar)
        {
            case (char)Keys.Enter:
                SendKeys.Send("{Tab}");
                break;
            default:
                break;
        }
    }
