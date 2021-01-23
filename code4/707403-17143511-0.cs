    Range range = SetRange();//Let's say range is set between A1 to D1
    object[] args = {1, 2, 3, 4 }; 
    
    //Directly
    range.Value = args;
    
    //By Reflection
    range.GetType().InvokeMember("Value", System.Reflection.BindingFlags.SetProperty, null, range, args);
