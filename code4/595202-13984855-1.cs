    internal static class MoveFactory
    {
        private static readonly IDictionary<String, Type> _moveTypes;
    
        static MoveFactory()
        {
            _moveTypes = LoadAllMoveTypes();
        }
    
        private static IDictionary<string, Type> LoadAllMoveTypes()
        {
            var asm =
                //Get all types in the current assembly
                from type in Assembly.GetExecutingAssembly().GetTypes()
                //Where the type is a class and implements "IMove"
                where type.IsClass && type.GetInterface("IMove") != null
                //Only select types that are decorated with our custom attribute
                let attr = type.GetCustomAttribute<MoveNameAttribute>()
                where attr != null
                //Return both the Name and the System.Type
                select new
                            {
                                name = attr.Name,
                                type
                            };
    
            //Convert the results to a Dictionary with the Name as a key
            // and the Type as the value
            return asm.ToDictionary(move => move.name, move => move.type);
        }
    
        internal static IMove CreateMove(String name)
        {
            Type moveType;
    
            //Check to see if we have an IMove with the specific key
            if(_moveTypes.TryGetValue(name, out moveType))
            {
                //Use reflection to create a new instance of that IMove
                return (IMove) Activator.CreateInstance(moveType);
            }
    
            throw new ArgumentException(
               String.Format("Unable to locate move named: {0}", name));
        }
    }
