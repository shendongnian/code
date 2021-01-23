    private void btnBenutz_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        foreach (string x in listBox1.Items)
        {
            sb.Append("\n" + x);
        }
        // then use sb.ToString() somewhere...
    }
