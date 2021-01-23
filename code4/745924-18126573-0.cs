    if(double.TryParse(textBox1.Text,outf))
    {
       lista.Add(f);
        i++;
        if (i == lista.Capacity)
        {
            lista.Capacity=lista.Capacity + 100;
        }
    }
