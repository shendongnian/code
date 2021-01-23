    using System;
    using Omu.ValueInjecter;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main(string[] args)
            {
                var call = new Call { Number = "001337", CustomerNumber = "000001" };
                var op = new Operation { ID = 1, CallNumber = "001337", TimeFrom = "08:00" };
                var customer = new Customer { Number = "000001", Name = "John Doe" };
    
                var model = new
                                {
                                    Call = call,
                                    Customer = customer,
                                    Operation = op
                                };
    
                var viewModel = new CallViewModel();
                viewModel.InjectFrom<FlatLoopValueInjection>(model);
    
                Console.WriteLine("Number:\t\t\t" + viewModel.CallNumber);
                Console.WriteLine("CustomerName:\t\t" + viewModel.CustomerName);
                Console.WriteLine("OperationTimeFrom:\t" + viewModel.OperationTimeFrom);
                Console.ReadLine();
            }
    
            class Call
            {
                public string Number { get; set; }
                public string CustomerNumber { get; set; }
            }
    
            class Operation
            {
                public int ID { get; set; }
                public string CallNumber { get; set; }
                public string TimeFrom { get; set; }
            }
    
            class Customer
            {
                public string Number { get; set; }
                public string Name { get; set; }
            }
    
            class CallViewModel
            {
                public string CallNumber { get; set; }
                public string CustomerName { get; set; }
                public string OperationTimeFrom { get; set; }
            }
        }
    }
