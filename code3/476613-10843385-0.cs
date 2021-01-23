    int value = 0;
    if(Int32.TryParse(textBox.Text, out value))
    {
       value += step;
       textBox.Text = value.ToString();
    }
    else
    {
       //inform user to enter int
    }
