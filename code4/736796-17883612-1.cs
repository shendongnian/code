    int num = -1
    
    if(int.TryParse(number.Text, out num))
        {
           if (num > 0 && num < 455)
           {
             //Do here 
           }
           else
           {
               MessageBox.Show("Enter Value between 1 to 454");
           }
        }
 
