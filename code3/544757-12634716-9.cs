    private void button3_Click(object sender, EventArgs e)
    {
         int indexOfQr = richTextBox1.Rtf.IndexOf(@"\qr", System.StringComparison.Ordinal);
         if (indexOfQr != -1)
            richTextBox1.Rtf = richTextBox1.Rtf.Remove(indexOfQr, @"\qr".Length);
    }
