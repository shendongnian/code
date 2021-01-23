    private void button1_Click (object sender, System.EventArgs e)
    {
         UsernameDecryptor decryptor = new UsernameDecryptor();
         string result = decryptor.Decrypt(inputTextBox.Text);
         outputTextBox.Text = result;
    }
