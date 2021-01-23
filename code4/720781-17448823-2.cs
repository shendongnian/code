    Delegate[] delegate_list = OnPost.GetInvocationList();
    
    Type formType = Type.GetType("System.Windows.Forms.Control, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
    var invokeRequiredProp = formType.GetProperty("InvokeRequired");
    foreach (OnPostHandler d in delegate_list)
    {
        if(formType != null) {
            var invokeRequired = invokeRequiredProp.GetValue(d.Target, null);
            if (invokeRequired) {
                formType.GetMethod("Invoke").Invoke(d.Target, new object[]{d});
            } 
            else {
               d();
           }
        } else {
            d();
        }
    }
