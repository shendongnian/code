    public partial class dateIN : UserControl
    {
       ...
       ...
       private bool AllowEditing()
       { return SomeCondition when SHOULD be allowed...; }
    
    
       public string Day
       {
          // only allow the set to apply the change if the "AllowEditing" condition
          // is true, otherwise, ignore the attempt to assign.
          set { if( AllowEditing() )
                   txtDay.Text = value; }
          get { return txtDay.Text; }
       }
    
       // same concept for month and year too
    }
