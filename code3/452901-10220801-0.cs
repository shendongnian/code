    public static void Main()
    {
    //Create an array of five ShippedOrder objects. 
        ShippedOrder[] myShippedOrder = new ShippedOrder[5];
        ShippedOrder[] checkDup = new ShippedOrder[5];
    //Prompt the user for values for each Orders object; do NOT allow duplicate order numbers and force the user to reenter 
    //    the order when a duplicate order number is entered.
            bool wronginput = false;
            for (int x = 0; x < myShippedOrder.Length; ++x)
            {
                int y = 0;
                myShippedOrder[x] = new ShippedOrder();
                checkDup[y] = new ShippedOrder();
                Console.Write("Please enter the order number for order {0}:  ", x + 1);
                checkDup[y].orderNumber = Convert.ToInt32(Console.ReadLine());             
                for (y = 0; y < checkDup.Length; ++y)
                {
                    if (checkDup[y] != null && myShippedOrder[x].Equals(checkDup[y]))
                    {
                        Console.WriteLine("Sorry, this order number has already been entered, please try again");
                        --x;
                        wronginput = true;
                        break;
                    }
                    else myShippedOrder[x].orderNumber = checkDup[y].orderNumber;
                }
                if(wronginput)
                    continue;
                Console.Write("Please enter the customers name for order {0}:  ", x + 1);
                myShippedOrder[x].customerName = Console.ReadLine();
                Console.Write("Please enter the quantity that was ordered for order {0}:  ", x + 1);
                myShippedOrder[x].quantityOrdered = Convert.ToInt32(Console.ReadLine());
                myShippedOrder[x].totalPrice = myShippedOrder[x].quantityOrdered * PRICEEACH + ShippedOrder.SHIPFEE;
        }
