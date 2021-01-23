    using System;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Threading.Tasks;
    
    class Test
    {
        const int Iterations = 1000000;
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                RunTest(ExecuteParallel);
                RunTest(ExecuteSerial);
            }
            
        }
        
        static void RunTest(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            Console.WriteLine("{0}: {1}", action.Method, sw.Elapsed);
        }
        
        static void ExecuteParallel()
        {
            var service = new Service();
            Parallel.For(0, Iterations, i => {
                dynamic user = new ExpandoObject();
                user.data = new ExpandoObject();
                user.data.id = i;
                user.data.name = "User Name";
                var parsed = service.Parse(user);
            });
        }
        
        static void ExecuteSerial()
        {
            var service = new Service();
            for (int i = 0; i < Iterations; i++)
            {
                dynamic user = new ExpandoObject();
                user.data = new ExpandoObject();
                user.data.id = i;
                user.data.name = "User Name";
                var parsed = service.Parse(user);
            }
        }
    }
    
    public class Service
    {
        public User Parse(dynamic dynamicUser)
        {
            if (dynamicUser.data != null)
            {
                return new User
                {
                    Id = dynamicUser.data.id,
                    Name = dynamicUser.data.name
                };
            }
            return null;
        }
    }
    
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
