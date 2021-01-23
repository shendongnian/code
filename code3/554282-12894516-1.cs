    public static class ControlExtensions
    {
        public static IEnumerable<T> AllControlsOfType<T>(this Control control) 
            where T : Control
        { 
             T found = control as T;
             if(found != null)
             {
                 yield return found;
             } 
       
             foreach (var child in control.Controls.Cast<Control>())
             {
                foreach (var item in AllControls<T>(child))
                {
                   yield return item;
                }
             }
        }
    }
