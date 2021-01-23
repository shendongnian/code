     Type IType = Type.Assembly.Load("YourProjectName").GetType("FunctionName");
     if (IType == null)
     {  
         Text = "Function Not Exist";
     }
     else
     {
         Text = "Function  Exist";
     }
