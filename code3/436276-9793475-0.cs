       int count = 0;
    
       public void Login()
       {
          if(count <= 3)
          {
               if (user_box.Text == "1111" && Password_box.Text == "Master")
               {
                     MessageBox.Show("Welcome Albert Einstein.");
               }
               else
               {
                     MessageBox.Show("No User Input.");
                     count++;
               }
           }
           else
           {
                user_box.Enabled = false;
                Password_box.Enabled = false;
           }
       }
