       //Write
        using (StreamWriter sw1 = new StreamWriter("DataNames.txt"))
        {
            sw1.WriteLine(textBox1.Text);
        }
    
        using (StreamWriter sw2 = new StreamWriter("DataNumbers.txt"))
        {
            sw2.WriteLine(textBox2.Text);
        }
    
    
        // Read
        foreach (var line in File.ReadAllLines("DataNames.txt"))
        {
            listBox1.Items.Add(line);
        }
    
        foreach (var line in File.ReadAllLines("DataNumbers.txt"))
        {
            listBox2.Items.Add(line);
        }
