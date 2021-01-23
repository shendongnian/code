    ArrayList libraries = new ArrayList();
    libraries.Add("somedll1.dll");
    libraries.Add("somedll2.dll");
    
    Console.WriteLine("Registering DDLs in the Gac");
    
    try
    {
        for (int i = 0; i < libraries.Count; i++)
        {
            // get the path from the running exe, and remove the running exe's name from it
            new System.EnterpriseServices.Internal.Publish().GacRemove(System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("ThisUtilitiesName.exe", "") + libraries[i]);
        }
    
        Console.WriteLine("Completed task successfully");
    }
    catch (Exception exp)
    {
        Console.WriteLine(exp.Message);
    }
