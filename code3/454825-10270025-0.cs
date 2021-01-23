    String input;
    String target = String.Empty;
    try {
    using (StreamReader sr = File.OpenText(newPath)) 
    { 
        while ((input = sr.ReadLine()) != null) 
        { 
            target += input;   
        }
    }
    TextBox1.Text = target;
    } catch { ... }
