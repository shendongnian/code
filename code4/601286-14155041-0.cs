    OpenFileDialog obj = new OpenFileDialog();
    if (obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        Assembly ass = Assembly.LoadFrom(obj.FileName);
        foreach(var type in ass.GetTypes())
        {
            MethodInfo[] members = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MemberInfo member in members)
            {
                Console.WriteLine(type.Name + "." + member.Name);
            }
        }
    }
