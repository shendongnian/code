    var shippedOrderNumbers = new List<int>();
    var validOrderNumbers = 0;
    while(validOrderNumbers < 5)
    {
         Console.WriteLine("Input order number:");
         var nextOrderNumber = Convert.ToInt32(Console.ReadLine());
         if(shippedOrderNumbers.Any(son => son == nextOrderNumber))
         {
             Console.WriteLine("Duplicate order number. Please enter another");
             continue;
         }
         shippedOrderNumbers.Add(nextOrderNumber);
         validOrderNumbers++;
    }
