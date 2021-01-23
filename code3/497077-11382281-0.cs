    List<string> Items = new List<string>() { "1", "2", "3" };
    foreach (string item in Items)
    {
        bool _Contains = LabelDetails.Content.ToString().Contains(item);
         if (_Contains == true)
            {
               break;
            }
     }
