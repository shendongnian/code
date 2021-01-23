       public class MyUserControl : UserControl 
       {
          private readonly int index;
     
          public MyUserControl(int index)
          {
             this.index = index;
      
             InitializeComponent(); // will init you sub controls: label and textbox
    
             // set name to label
    
          } 
    
          public int Index
          {
             get { return index; }
          } 
       }
