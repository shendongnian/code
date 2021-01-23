    static void FindAttributes(String^ assemblyPath)
    {
        Assembly^ assembly = Assembly::ReflectionOnlyLoadFrom(assemblyPath);
        
        for each (Type^ typ in assembly->GetTypes())
        {
            for each (CustomAttributeData^ attr 
                in CustomAttributeData::GetCustomAttributes(typ))
            {
                Console::WriteLine( "{0}: {1}", typ, attr);
            }
        }
    }
