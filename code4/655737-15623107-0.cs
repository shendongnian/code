    System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();
    Type[] Types = myAssembly.GetTypes();
    foreach (Type myType in Types)
    {
       if (myType.BaseType == null) continue;
    
           if (myType.BaseType.FullName == "System.Windows.Forms.Form")
           {
               //Application.Run(myType.Name());  //This does not work
               //MessageBox.Show(myType.Name);
               var myForm = (System.Windows.Forms.Form)
                      Activator.CreateInstance(myAssembly.Name, myType.Name);
               myForm.Show();
           }   
    
    }  
