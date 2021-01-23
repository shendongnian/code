    private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
                ComboBox cb =  (ComboBox )sender ;
                LanguageSelection = cb.SelectedItem.ToString();
                string[] LanguageTag = LanguageSelection.Split(' ');
                //string tag have to be declared in your application at a global level
                tag = LanguageTag[1].Replace("<", "").Replace(">", "");
             
    }
