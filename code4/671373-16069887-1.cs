    namespace ConsoleApplication2
    {
        using System;
        using System.Linq;
    
        public class Order : IComparable<Order>
        {
            public const double PriceEach = 19.95;
    
            public Order()
            {
            }
    
            public Order(int number, string name, int quanity)
            {
                this.OrderNumber = number;
                this.CustomerName = name;
                this.QuanityOrdered = quanity;
            }
    
            public int OrderNumber { get; set; }
    
            public string CustomerName { get; set; }
    
            public int QuanityOrdered { get; set; }
    
            public int CompareTo(Order o)
            {
                return this.OrderNumber.CompareTo(o.OrderNumber);
            }
    
            public override bool Equals(object e)
            {
                int compareTo;
                int.TryParse(e.ToString(), out compareTo);
                return this.OrderNumber == compareTo;
            }
    
            public override int GetHashCode()
            {
                return Convert.ToInt32(this.OrderNumber);
            }
    
            public override string ToString()
            {
                return "Shipped order number " + this.OrderNumber + " for customer " + this.CustomerName + " " + this.QuanityOrdered +
                " @ $" + PriceEach + " each.";
            }
        }
    
        public class ShippedOrder : Order
        {
            public const int ShippingFee = 4;
    
            public double TotalPrice
            {
                get
                {
                    return (this.QuanityOrdered * PriceEach) + ShippingFee;
                }
            }
    
            public override string ToString()
            {
                return base.ToString() + " Shipping is $" + ShippingFee + ". Total is $" + this.TotalPrice;
            }
        }
    
        public class Program
        {
            private static readonly int[] OrderNumbers = new int[5];
            private static readonly ShippedOrder[] ShippedOrders = new ShippedOrder[5];
    
            public static void Main(string[] args)
            {
                double sum = 0;
    
                for (var i = 0; i < OrderNumbers.Length; i++)
                {
                    OrderNumbers[i] = InputOrderNumber();
                    var name = InputCustomerName();
                    var quantity = InputQuantity();
                    ShippedOrders[i] = new ShippedOrder { CustomerName = name, QuanityOrdered = quantity, OrderNumber = OrderNumbers[i] };
                    sum += ShippedOrders[i].TotalPrice;
                }
    
                Array.Sort(ShippedOrders);
                foreach (var t in ShippedOrders)
                {
                    Console.WriteLine(t.ToString());
                }
    
                Console.WriteLine();
                Console.WriteLine("Total for all orders is {0:c} ", sum);
                Console.WriteLine();
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
    
            private static int InputOrderNumber()
            {
                Console.Write("Enter order number: ");
                var parsedOrderNumber = InputNumber();
    
                if (ShippedOrders.Any(shippedOrder => shippedOrder != null && shippedOrder.OrderNumber.Equals(parsedOrderNumber)))
                {
                    Console.WriteLine("Order number {0} is a duplicate.", parsedOrderNumber);
                    return InputOrderNumber();
                }
    
                return parsedOrderNumber;
            }
    
            private static string InputCustomerName()
            {
                Console.Write("Enter customer name: ");
                var customerName = Console.ReadLine();
                if (customerName == null || string.IsNullOrEmpty(customerName.Trim()))
                {
                    Console.WriteLine("Customer name may not be blank.");
                    return InputCustomerName();
                }
    
                return customerName;
            }
    
            private static int InputQuantity()
            {
                Console.Write("Enter quantity: ");
                return InputNumber();
            }
    
            private static int InputNumber()
            {
                int parsedInput;
                var input = Console.ReadLine();
                if (!int.TryParse(input, out parsedInput))
                {
                    Console.WriteLine("Enter a valid number.");
                    return InputNumber();
                }
    
                return parsedInput;
            }
        }
    }
