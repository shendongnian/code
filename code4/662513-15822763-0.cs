           public string TextSwitcher(int choice)
           {
              Switch(choice) // choice is an int 
              {
    // 1,2,3 is not an serial no they will pass by parameter  
                 case(1):
                  return "Please push one of these buttons :";
                 brake;
                 case(2):
                  return = "You just pushed YES button";
                 brake;
                 case(3)
                  return = "You just pushed NO button";
                 brake;
              }
           }
    
       private void buttonYes_Click(object sender, EventArgs e)
       {
           label.Text = TextSwitcher(2);
       }
       private void buttonNo_Click(object sender, EventArgs e)
       {
           label.Text = TextSwitcher(3);
       }
