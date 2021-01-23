    internal class Program
        {
            private class AccountOperation
            {
                public int Id { get; set; }
                public int Amount { get; set; }
            }
    
            private static void Main(string[] args)
            {
                List<AccountOperation> ops = new List<AccountOperation>
                {
                    new AccountOperation { Id = 1, Amount = 300},
                    new AccountOperation { Id = 1, Amount = -300},
                    new AccountOperation { Id = 2, Amount = 100},
                    new AccountOperation { Id = 3, Amount = 50},
                    new AccountOperation { Id = 2, Amount = -20},
                };
    
                foreach (var operationsByAccount in ops
                    .OrderByDescending(z => z.Amount)  // Orders all amounts descending
                    .GroupBy(z => z.Id) // Groups by account ID
                    .OrderByDescending(z => z.Sum(z2 => z2.Amount))) // Orders groups of operations per accounts descending (by sum of amounts)
                {
                    Console.WriteLine("Operation " + operationsByAccount.Key);
                    foreach (var operation in operationsByAccount)
                    {
                        Console.WriteLine("\tAmout " + operation.Amount);
                    }
                }
    
                Console.ReadLine();
            }
        }
