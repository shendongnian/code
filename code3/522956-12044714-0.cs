    using System.Diagnostics;
    using System.Reflection;
    public SomeConstructor(int? par1, int? par2, string par3)
    {
        CheckThrowNull(par1, par2, par3);
        //rest of constructor code...
    }
    ///<param name="values"> Values must be given in order </param>
    public static void CheckThrowNull(params object[] values)
    {
        StackTrace stackTrace = new StackTrace();
        ParameterInfo[] parameters = stackTrace.GetFrame(1).GetMethod().GetParameters(); //get calling method's parameters (or constructor)
        if (parameters.Length != values.Length)
        {
            throw new ArgumentException("Incorrect number of values passed in");
        }
        for (int i = 0; i < parameters.Length; i++)
        {
            if (values[i] == null)
            {   
                //value was null, throw exception with corresponding parameter name
                throw new ArgumentNullException(parameters[i].Name);
            }
        }
    }
