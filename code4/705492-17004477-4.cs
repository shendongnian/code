    class AirCraft
    {
        public class fighterJets
        {
            public static string forSeas = "fj_f18";
            public static string ForLand = "fj_f15";
        }
        public class helicopters 
        {
            public static string openFields = "Apachi";
            public static string CloseCombat = "Cobra";
    
        }
    }
    IEnumerable<FieldInfo> GetAllStaticFields(Type type) 
    {
        return type.GetNestedTypes().SelectMany(GetAllFields)
                   .Concat(type.GetFields(BindingFlags.Public | BindingFlags.Static));
    }
    IDictionary<string, object> GetAllStaticFieldNamesAndValues(Type type) 
    {
        return GetAllStaticFields(type)
            .ToDictionary(f => f.Name, f => f.GetValue(null));
    }
