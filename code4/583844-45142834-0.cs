    // Try this to take the second line 
    string line;
    using (var file_read = new StreamReader(your_file))
    {
        file_read.ReadLine(); 
        line = file_read.ReadLine();
    }
    textBox1.Text = line.ToString();
