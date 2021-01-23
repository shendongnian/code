    public static class ControlExtensions
    {
         public static void SetText(this Control ctrl, string text) 
         { 
              ctrl.Text = text;
         }
         public static String GetText(this Control ctrl)            
         { 
              return ctrl.Text;
         }
    }
