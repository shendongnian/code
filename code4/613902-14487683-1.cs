     public TextBox FindTextbox(string name)
     {
         foreach (Control item in parentControl.Children) //based on parent type it my be .Childern, .Items , ...
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
