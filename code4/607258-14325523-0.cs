     int x, y, result;
     if (int.TryParse(txtbox1.Text, x)
     {
         if (int.TryParse(txtbox2.Text, y)
         {
              result = x + y;
         }
         else
             //error message
     }
     else
         // error message
