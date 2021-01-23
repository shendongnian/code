    namespace ConsoleApplication1
    {
        using System;
        using System.Threading.Tasks;
        using AppDomainToolkit;
        using System.Collections.Generic;
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var context1 = AppDomainContext.Create())
                using (var context2 = AppDomainContext.Create())
                using (var context3 = AppDomainContext.Create())
                {
                    var pizzaInContext1 = Remote<Pizza>.CreateProxy(context1.Domain, "Hawaiian");
    
                    // manipulate object from current app domain
                    pizzaInContext1.RemoteObject.AddTopping(new Topping("Cheese"));
    
                    // manipulate object from context 2
                    RemoteAction.Invoke(
                        context2.Domain,
                        pizzaInContext1.RemoteObject,
                        new Topping("Pineapple"),
                        (pizza, topping) =>
                        {
                            pizza.AddTopping(topping);
                        });
    
                    // manipulate object, adding info from context 3
                    RemoteAction.Invoke(
                        context3.Domain,
                        pizzaInContext1.RemoteObject,
                        (pizza) =>
                        {
                            pizza.AddTopping(new Topping("Ham"));
                        });
    
                    Console.WriteLine(pizzaInContext1.RemoteObject.ToString());
                }
    
                Console.ReadKey();
            }
        }
    
        class Pizza : MarshalByRefObject
        {
            private readonly IList<Topping> toppings;
    
            public Pizza(string name)
            {
                this.Name = name;
                this.toppings = new List<Topping>();
            }
    
            public string Name { get; private set; }
    
            public void AddTopping(Topping topping)
            {
                this.toppings.Add(topping);
            }
    
            public override string ToString()
            {
                var pizza = this.Name + " with toppings: [";
                for (int i = 0; i < this.toppings.Count; i++)
                {
                    pizza += this.toppings[i].Name;
                    if (i < this.toppings.Count - 1)
                    {
                        pizza += ",";
                    }
                }
                pizza += "]";
                return pizza;
            }
        }
    
        [Serializable]
        class Topping
        {
            public Topping(string name)
            {
                this.Name = name;
            }
    
            public string Name { get; private set; }
    
            public override string ToString()
            {
                return this.Name;
            }
        }
    }
