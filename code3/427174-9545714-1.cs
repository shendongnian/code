    object[] productAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), true);
    if (productAttributes.Length > 0 && productAttributes[0] is AssemblyProductAttribute)
    {
        string productName = (productAttributes[0] as AssemblyProductAttribute).Product;
        MessageBox.Show(productName);
    }
