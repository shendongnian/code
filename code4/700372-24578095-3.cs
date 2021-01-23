    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqAggregateDemo
    {
        public class Program
        {
            
            public static void Main(string[] args)
            {            
                var incomes = new List<IncomeData>() {
                    new IncomeData("abc0123", 15500),
                    new IncomeData("def4567", 12300),
                    new IncomeData("ghi8901", 17100)
                };
                
                string message = incomes.
                    Select(inc => inc.ToString()).
                    Aggregate((buffer, next) => buffer + "\n" + next.ToString());
                
                Console.WriteLine("Income data per person:\n" + message);
            }
            
            public struct IncomeData
            {
                public readonly string Id;
                public readonly int Income;
                
                public IncomeData(string id, int income)
                {
                    this.Id = id;
                    this.Income = income;
                }
                
                public override string ToString()
                {
                    return String.Format(
                        "Id: {0}, Income:{1}",
                        this.Id,
                        this.Income);
                }
            }
        }
    }
