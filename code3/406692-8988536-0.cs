        var constants = new Constants();
        foreach (var prop in typeof(Constants).GetFields())
        {
            string test = prop.GetRawConstantValue().ToString();
            
            if (test == "test1")
                MessageBox.Show("You got me!");
        }
