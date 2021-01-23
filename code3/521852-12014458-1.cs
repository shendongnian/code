    private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
                ComboBox cb =  (ComboBox )sender ;
                LanguageSelection = cb.SelectedItem.ToString();
                string[] LanguageTag = LanguageSelection.Split(' ');
                string tag = LanguageTag[1].Replace("<", "").Replace(">", "");
                return tag;
    }
