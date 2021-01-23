    void licz()
    {
        int result = 0;
        for (int i = 0; i < 20; i++)
        {
            result += i;
            textBox1.Text += result.ToString() + Environment.NewLine;               
        }
        MessageBox.Show("Wynik: " + result);
    }
