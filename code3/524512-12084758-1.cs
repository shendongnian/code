    class MyClass
    {
    
     public static CreditCard FindCard(List<CreditCard> Cust, string Name) 
    
        {
           foreach(CreditCard cust in Cust)
           {
               if(cust.Name == Name)
               {
                   return cust;
               }
           }
           return null;
    
        }
    
    public static int main()
    {
    // Populate the list
    List<CreditCard> cards = new List<CreditCard>{ new CreditCard(...), new CreditCard(...)}
    
    Console.WriteLine("Enter your name: ");
    String name = Console.ReadLine();
    
    CreditCard cc = FindCard(cards, name);
    
    if (cc != null)
    {
        Console.WriteLine(cc.Number); // And for all fields in CreditCard class
        ...
    }    
    Console.ReadKey();
    
    return 0;
    }
