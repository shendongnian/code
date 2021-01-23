    string outPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    outPath = System.IO.Path.Combine(outPath, "MyResources.resx");
    using (System.Resources.ResXResourceWriter rw = new System.Resources.ResXResourceWriter(outPath))
    {
       rw.AddResource("ComboBox1Values", new string[] { "Car", "Train" });
       rw.Generate();
       rw.Close();
    }
