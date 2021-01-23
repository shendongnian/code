        string str = TextBox1.Text.Trim();
        if(str.contains(your_matching_string))
        {
            args.IsValid = true;   
        }
        else
        {
           args.IsValid = false;   
         }
  
