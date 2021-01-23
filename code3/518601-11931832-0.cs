        int value = 0;
        if (Int32.TryParse(textbox.Text, out value))
        {
           if (value == 1)
           {
              ... //Do something
           }
           else if (value == 2)
           {
              ... //Do something else
           }
           else
           {
              ... //Do something different again
           }
       }
       else
       {
           ... //Incorrect format...
       }
