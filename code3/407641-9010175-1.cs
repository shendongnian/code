    Task.Factory.StartNew(() =>
    {
        foreach (string s in StaticClassHelper.GetStrings(inputString))
        {
            string toAdd = s;
            listBox1.Invoke(new Action(() => listBox1.Add(toAdd)));
        }
    }
    
