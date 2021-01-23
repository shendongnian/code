    private static int[] GetValues(Type enumType)
    {
        if (enumType.BaseType == typeof (Enum))
        {
            //get the public static fields (members of the enum)
            var fi = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
            //create a new enum array
            var values = new int[fi.Length];
            //populate with the values
            for (var iEnum = 0; iEnum < fi.Length; iEnum++)
            {
                values[iEnum] = (int) fi[iEnum].GetValue(null);
            }
            //return the array
            return values;
        }
 
        //the type supplied does not derive from enum
        throw new ArgumentException("enumType parameter is not a System.Enum");
    }
