    public class TypeMain
    {
        public static void Main() 
        {
            Type myType =(typeof(MyTypeClass));
            // Get the public properties.
            PropertyInfo[] myPropertyInfo = myType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
            Console.WriteLine("The mumber of public properties is {0}.", myPropertyInfo.Length);
            // Display the public properties.
            DisplayPropertyInfo(myPropertyInfo);
            // Get the nonpublic properties.
            PropertyInfo[] myPropertyInfo1 = myType.GetProperties(BindingFlags.NonPublic|BindingFlags.Instance);
            Console.WriteLine("The number of protected properties is {0}.", myPropertyInfo1.Length);
            // Display all the nonpublic properties.
            DisplayPropertyInfo(myPropertyInfo1);		
        }
        public static void DisplayPropertyInfo(PropertyInfo[] myPropertyInfo)
        {
            // Display information for all properties.
            for(int i=0;i<myPropertyInfo.Length;i++)
            {
                PropertyInfo myPropInfo = (PropertyInfo)myPropertyInfo[i];
                Console.WriteLine("The property name is {0}.", myPropInfo.Name);
                Console.WriteLine("The property type is {0}.", myPropInfo.PropertyType);
            }
        }
