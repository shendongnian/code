    MethodInfo methodOnClick = typeof(Button).GetMethod("OnClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    
    // and then...
    
    methodOnClick.Invoke(myButton, new Object[] { EventArgs.Empty });
