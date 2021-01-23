    int Selected = -1;    
    int count = ComboBox1.Items.Count;
        for (int i = 0; (i<= (count - 1)); i++) 
         {        
             ComboBox1.SelectedIndex = i;
            if ((string)(ComboBox1.SelectedValue) == "SearchValue") 
            {
                Selected = i;
                break;
            }
    
        }
    
        ComboBox1.SelectedIndex = Selected;
