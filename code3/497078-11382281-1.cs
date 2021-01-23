    List<string> Items = new List<string>() { "1", "2", "3" };
    foreach (string item in Items)
    {
        bool _Contains = TextBox.Text.Contains(item);
         if (_Contains == true)
            {
               //do something
            }
        else
           {
              //do something
           }
     }
