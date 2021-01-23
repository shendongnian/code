    string temp = textBox1.Text;
    switch (temp.Length)
    {
        case 0:
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            break;
        case 1:
            // Via the indexer...
            textBox2.Text = temp[0].ToString();
            textBox3.Text = "";
            textBox4.Text = "";
            break;
        case 2:
            // Via Substring
            textBox2.Text = temp.Substring(0, 1);
            textBox3.Text = temp.Substring(1, 1);
            textBox4.Text = "";
            break;
        default:
            textBox2.Text = temp.Substring(0, 1);
            textBox3.Text = temp.Substring(1, 1);
            textBox4.Text = temp.Substring(2, 1);
            break;
    }
