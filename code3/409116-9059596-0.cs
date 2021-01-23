     //Event Handler Class
     public class SpecialIndexMonitor
     {
          public event EventHandler<SpecialIndexEventArgs> SpecialIndexSelected;
          //Custom Function to handle Special Index
          public void ProcessRequest(object sender, System.EventArgs e)
          {
               //Your custom logic
               //Your code goes here
               //Raise event
               if(SpecialIndexSelected != null)
               {
                   SpecialIndexEventArgs args = new SpecialIndexEventArgs{
                        SelectedIndex = ((ComboBox) sender).SelectedIndex;
                   };
                   SpecialIndexSelected(this, args);
               }
          }
     }
     //Custom Event Args
     public class SpecialIndexEventArgs : EventArgs
     {
         //Custom Properties
         public int SelectedIndex { get; set; } //For Example
         //Default Constructor
         public SpecialIndexEventArgs ()
         {
         }
     }
