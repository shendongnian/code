    static void Main(string[] args) {
        Q q = new Q();
        Type type = q.GetType();
    
        Type aType = typeof(A);
    
        foreach (var fi in type.GetFields()) {
            object fieldValue = fi.GetValue(q);
            var fieldType = fi.FieldType;
            while (fieldType != aType && fieldType != null) {
                fieldType = fieldType.BaseType;
            }
            if (fieldType == aType) {
                foreach (var pi in fieldType.GetProperties()) {
                    Console.WriteLine("Property {0} = {1}", pi.Name, pi.GetValue(fieldValue, null));
                }
            }
            Console.WriteLine();
        }
    
        Console.ReadLine();
    }
