    static class GrottyHacks
    {
        internal static T Cast<T>(object target, T example) //CAST TO SPECIFIED TYPE
        {
            return (T) target;
        }
    }
    
    class CheesecakeFactory
    {
        static object CreateCheesecake()
        {
            return new { Fruit="Strawberry", Topping="Chocolate" };
        }
        
        static void Main()
        {
            object weaklyTyped = CreateCheesecake(); //ANONYMOUS TYPE GENERATION
            var stronglyTyped = GrottyHacks.Cast(weaklyTyped,
                new { Fruit="", Topping="" }); //"MAPPING"
            
            Console.WriteLine("Cheesecake: {0} ({1})",
                stronglyTyped.Fruit, stronglyTyped.Topping);            
        }
    }
