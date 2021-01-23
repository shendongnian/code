    string selectedLanguage = comboBoxLang.Text; // Comes from a menu option
    string resourceFile = string.Empty;
    /***/
    Logic to retrieve the proper resourceFile depending on the selectedLanguage.
    /***/
    ResourceManager rm = new ResourceManager(resourceFile, Assembly.GetExecutingAssembly());
    // Set your label text.
    lblName.Text = rm.GetString("lblName");
