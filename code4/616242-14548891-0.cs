    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox tb=sender as TextBox;
        string text=tb.Text;
        switch (text.Length)
        { 
            case 1:
                if (!char.IsLetter(text[0]))
                    tb.Text = "";
                break;
            case 2:
                if (!char.IsLetter(text[1]))
                    tb.Text = text.Remove(1);
                break;
            case 3: 
                if (!char.IsNumber(text[2]))
                    tb.Text = text.Remove(2);
                break;
            case 4:
                if (!char.IsNumber(text[3]))
                    tb.Text = text.Remove(3);
                break;
            default:
                if(text.Length>4)
                    tb.Text = text.Substring(0, 4);
                break;
        }
        textBox1.Select(tb.Text.Length, 0);
    }
