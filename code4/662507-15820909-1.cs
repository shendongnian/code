    public partial class Form1 : Form
    {
       public int choice=0;
       public Form1()
       {
           buttonYes.Click += (s,e) => { 
           choice = 1; 
           ChangeText(choice);};
           buttonNo.Click += (s,e) => {
           choice = 2;
           ChangeText(choice);};
       }
     
      private void ChangeText(int userChoice)
      { 
        if(choice == 0)
             label.Text = "Please push one of these buttons :";
            
          else if(choice == 1)
             label.Text = "You just pushed YES button";
         
          else if(choice == 2)
           label.Text = "You just pushed NO button";
      }
    } 
