    public class Request
    {
        public Type ReturnType;
        public string Key { get; set; }
        public Request(string Key, Type returnType)
        {
            this.Key = Key;
            this.ReturnType = returnType;
        }
    }
    
    public class Response
    {
        public object value;
        public Type returnType;
    }
    
    //Singleton processor to get data out of cache
    public class CacheProcessor
    {
        private static CacheProcessor instance;
       
        public static CacheProcessor Process
        {
            get
            {
                if (instance == null)
                    instance = new CacheProcessor();
                return instance;
            }
        }
    
        private Dictionary<Type, Func<Request, object>> Processors = new Dictionary<Type, Func<Request, object>>();
    
        private CacheProcessor()
        {
            CreateAvailableProcessors(); 
        }
    
        //All available processors available here
        //You could change type to string or some other type 
        //to extend if you need something like "CrazyZipUtility" as a processor
        private void CreateAvailableProcessors()
        {
            Processors.Add(typeof(string), ProcessString);
            Processors.Add(typeof(byte[]), ProcessByteArry);   
        }
    
        //Fake method, this should encapsulate all crazy 
        //cache code to retrieve stuff out
        private static string CacheGetKey(string p)
        {
            return "1dimd09823f02mf23f23f0";  //Bullshit data
        }
    
        //The goood old tryBlah... So Sexy
        public Response TryBlah(Request request)
        {
            if (Processors.ContainsKey(request.ReturnType))
            {
                object processedObject = Processors[request.ReturnType].Invoke(request);
                return new Response()
                {
                    returnType = request.ReturnType,
                    value = processedObject
                };
            }
            return null;
        }
    
        //Maybe put these in their own class along with the dictionary
        //So you can maintain them in their own file
        private static object ProcessString(Request request)
        {
            var value = CacheGetKey(request.Key);
            //Do some shit
            return value;
        }
    
        private static object ProcessByteArry(Request request)
        {
            var value = CacheGetKey(request.Key);
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(value);
            return bytes;
        }
    }
