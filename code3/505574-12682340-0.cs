    private void button1_Click(object sender, EventArgs e)
    {
        const int MAX_BUFFER = 2048;
        byte[] Buffer = new byte[MAX_BUFFER];
        int BytesRead;
        using (System.IO.FileStream fileStream = new FileStream(textBox2.Text, FileMode.Open, FileAccess.Read))
            while ((BytesRead = fileStream.Read(Buffer, 0, MAX_BUFFER)) != 0)
            {
                string text = (Convert.ToBase64String(Buffer));
                textBox1.Text = text;
            }
}
