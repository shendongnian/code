    private void Form1_Load(object sender, EventArgs e)
    {
       foreach (System.Windows.Forms.Keys key in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
       {
           comboBoxKeys.Items.Add(new { Value = key, Description = GetDescription(key) });
       }
    
       comboBoxKeys.DisplayMember = "Description";
    }
    
    private string GetDescription(System.Windows.Forms.Keys key)
    {
        switch(key)
        {
            case Keys.OemPipe:
                return "Better oem pipe description";
    
            case Keys.HanjaMode:
                return "Ninja mode";
    
            default:
                return Enum.GetName(key.GetType(), key); // default name
        }
    }
