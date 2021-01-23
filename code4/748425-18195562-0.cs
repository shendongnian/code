    public class TypeNotImplementedException : Exception {
        public Type ToType { get { return _ToType; } }
        private readonly Type _ToType;
        public Type FromType { get { return _FromType; } }
        private readonly Type _FromType;
        public override System.Collections.IDictionary Data {
            get {
                var data = base.Data ?? new Hashtable();
                data["ToType"] = ToType;
                data["FromType"] = FromType;
                return data;
            }
        }
        public TypeNotImplementedException(Type toType, Type fromType, Exception innerException) 
            : base("Put whatever message you want here.", innerException) {
            _ToType = toType;
            _FromType = fromType;
        }
    }
    class Program {
        private static T Cast<T>(object obj) {
            try {
                return (T)obj;
            }
            catch (InvalidCastException ex) {
                throw new TypeNotImplementedException(typeof(T), obj.GetType(), ex);
            }
        }
        static void Main(string[] args) {
            try {
                Cast<string>("hello world" as object);
                Cast<string>(new object());
            }
            catch (TypeNotImplementedException ex) {
                Console.WriteLine(ex);
            }
        }
    }
