    StringBuilder sb = new StringBuilder();
    foreach (char c in Player.Character)
    {
        if (c == '[')
            break;
        sb.Append(c);
    }
    textBox1.Text = sb.ToString();
