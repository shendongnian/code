    using System;
    using System.Security.Permissions;
    public class Test
    {
    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
    public static void Example()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        try
        {
            throw new Exception("1");
        }
        catch (Exception e)
        {
            Console.WriteLine("Catch clause caught : " + e.Message);
        }
        throw new Exception("2");
        // Output: 
        //   Catch clause caught : 1 
        //   MyHandler caught : 2
    }
    static void MyHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception)args.ExceptionObject;
        Console.WriteLine("MyHandler caught : " + e.Message);
    }
    public static void Main()
    {
        Example();
    }
}
