    static partial  class Parameter<T> where T : AnAbstract
    {
        public static string Name { get; set; }
        //etc
    }
    static partial class Parameter<T> where T : AnAbstract
    { 
        static Parameter ()
        {
            AnAbstract instance = (AnAbstract)Activator.CreateInstance(typeof(T));
            Parameter<T>.Name = instance.Name;
            //etc
        }
    }
    
