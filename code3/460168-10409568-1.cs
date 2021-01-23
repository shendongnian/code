    protected void btnFormat_Click(object sender, EventArgs e)
    {
        string formattedString = "";
        foreach (char c in this.txtOriginalString.Text.ToCharArray())
            formattedString += c + "-";
        this.txtFormattedString.Text = formattedString;
    }
