     public TextBox FindTextbox(string name)
     {
         foreach (Control item in parentControl.Children)
         {
             if (item is TextBox)
             {
                 TextBox temp = item as TextBox;
                 if (temp.Name == name)
                 {
                     return temp;
                 }
             }
         }
     }
