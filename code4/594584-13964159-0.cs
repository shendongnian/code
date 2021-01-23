    private void btnModel_Click(object sender, EventArgs e)
    {
        byte[] bCommand = Encode("C11", "");
        WriteData(bCommand);  // bCommand will now exist in this context
    }
