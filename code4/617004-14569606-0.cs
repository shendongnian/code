    private void writeText(TextBox textBox, string text)
    {
        for (int i = 0; i < 500; i++)
        {
            Invoke(new MethodInvoker(() =>
            {
                textBox.Text += text;
            }));
        }
    }
