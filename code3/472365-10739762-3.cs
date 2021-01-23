    foreach (string line in Properties.Settings.Default.ButtonStringCollection)
    {
        if (!String.IsNullOrWhitespace(line))
        {
            // The line will be in format x;y;name
            string[] parts = line.Split(';');
            if (parts.Length >= 3)
            {
                int x = Convert.ToInt32(parts[0]);
                int y = Convert.ToInt32(parts[1]);
            
                make_Book(x, y, parts[2]);
            }
        }
    }
    
