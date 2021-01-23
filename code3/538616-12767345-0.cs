    public static void Chargeur()
    {
        var Assemblées_Chargées = (from Assembly Assemblée in AppDomain.CurrentDomain.GetAssemblies() where !(Assemblée is System.Reflection.Emit.AssemblyBuilder) && (Assemblée.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder") && (!Assemblée.GlobalAssemblyCache) && (Assemblée.CodeBase != Assembly.GetExecutingAssembly().CodeBase) select Assemblée).ToList();
        var Chemins_Chargés = Assemblées_Chargées.Select(Assemblée => Assemblée.Location).ToArray();
        var Chemins_Référencés = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
        var Assemblées_NonChargées = Chemins_Référencés.Where(Références => !Chemins_Chargés.Contains(Références, StringComparer.InvariantCultureIgnoreCase)).ToList();
        Assemblées_NonChargées.ForEach(path => Assemblées_Chargées.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
    }
