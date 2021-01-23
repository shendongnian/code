    Type ucApprovedType = ucApproved.GetType();
    System.Reflection.FieldInfo[] fieldInfo = ucApprovedType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    foreach (System.Reflection.FieldInfo ucFieldInfo in fieldInfo)
    {
        //get its current value
        Control control = ucFieldInfo.GetValue(ucApproved) as Control;
        if (control == null)
        {
            control = new Control();
            //Set instantiated control back to ucApproved item
            ucFieldInfo.SetValue(ucApproved, control);
        }
    }
