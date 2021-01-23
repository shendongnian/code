    // Not public outside of this assembly.
    static class MyServiceHelper
    {
        public static IEnumerable<Type> GetDataContractTypes(ICustomAttributeProvider paramIgnored)
        {
            // Get the assembly with the concrete DataContracts.
            Assembly ass = Assembly.Load("MyService");  // MyService.dll
            // Get all of the types in the MyService assembly.
            var assTypes = ass.GetTypes();
            // Create a blank list of Types.
            IList<Type> types = new List<Type>();
            // Get the base class for all MyService data contracts
            Type myDataContractBase = ass.GetType("MyDataContractBase", true, true);
            // Add MyService's data contract Types.
            types.Add(assTypes.Where(t => t.IsSubclassOf(myDataContractBase)));
            // Add all the MyService data contracts to the service's known types so they can be serialized.
            return types;
        }
    }
