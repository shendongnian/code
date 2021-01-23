    int num = Int32.Parse(textBox1.Text);
    if (num > 0)
    {
        sum += num;
        if (num > current)
        {
            label1.Text = num.ToString();
            current = num;
        }
    }
    else
    {
        label2.Text = sum.ToString();
        // stop accepting input, perhaps exit?
    }
