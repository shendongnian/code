    string name;
    lstResult.Items.Clear();
    using (StreamReader sr = File.OpenText("../Name_Check.txt"))
    {
        while ((name = sr.ReadLine()) != null)
        {
            if (txtInput.Text.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            {
                lstResult.Items.Add(name);
