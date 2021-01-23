    class Program
    {
        static void Main(string[] args)
        {
            var methodsCallingDbConnectionOpen = AssemblyDefinition.ReadAssembly(typeof(Program).Assembly.Location)
                .MainModule
                .GetTypes()
                .SelectMany(type => type.Methods)
                .Where(method => method.HasBody &&
                    method.Body.Instructions.Any(instruction =>
                        instruction.OpCode.Code == Code.Callvirt && instruction.Operand is MethodReference &&
                        ((MethodReference)instruction.Operand).FullName.Contains("System.Data.Common.DbConnection::Open")));
            
            foreach (var method in methodsCallingDbConnectionOpen)
            {
                Console.WriteLine(method);
            }
            Console.ReadLine();
        }
        static void Foo()
        {
            using (var connection = new SqlConnection())
            {
                connection.Open();
            }
        }
    }
