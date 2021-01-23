    using System.Reflection;
    foreach (FieldInfo fInfo in CWindow.GetType().GetFields())
    {
        if (fInfo.FieldType.Name == "DependencyProperty")
        {
            if (fInfo.GetValue(null) == "Status")
            {
                Console.WriteLine("Status Property already Registered");
            }
        }
    }
