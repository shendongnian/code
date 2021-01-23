    int i;
    if (textBox1.TryGetInt(out i))
    {
        MessageBox.Show(i.ToString());
    }
    else
    {
        // no integer entered
    }
