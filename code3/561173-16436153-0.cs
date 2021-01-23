    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem.ToString() == "English")
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            ChangeLanguage("en");
        }
        else if (comboBox1.SelectedItem.ToString() == "Spanish")
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            ChangeLanguage("es-ES");
        }
        else if (comboBox1.SelectedItem.ToString() == "French")
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            ChangeLanguage("fr-FR");
        }
    }
    private void ChangeLanguage(string lang)
    {
        foreach (Control c in this.Controls)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserLogin));
            resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            if (c.ToString().StartsWith("System.Windows.Forms.GroupBox"))
            {
                foreach (Control child in c.Controls)
                {
                    ComponentResourceManager resources_child = new ComponentResourceManager(typeof(UserLogin));
                    resources_child.ApplyResources(child, child.Name, new CultureInfo(lang));
                }
            }
        }
    }
