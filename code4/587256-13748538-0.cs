    class CarList : LinkedList<Car>
    {
        public void AddCar(Car newCar)
        {
            if (this.Count == 0)
            {
                AddFirst(newCar);
            }
            else
            {
                var referenceCar = Find(this.OrderByDescending(i => i.Price).Where(i => newCar.Price > i.Price).FirstOrDefault());
                if (referenceCar == null)
                {
                    AddBefore(First, newCar);
                }
                else
                {
                    this.AddAfter(referenceCar, newCar);
                }
            }
        }
    }
    class Car
    {
        public int Price { get; set; }
        public Car(int price)
        {
            Price = price;
        }
    }
    static void Main(string[] args)
    {
        var list = new CarList();
        list.AddCar(new Car(20000));
        list.AddCar(new Car(10000));
        list.AddCar(new Car(15000));
        foreach (var item in list)
        {
            Console.WriteLine("Price {0}", item.Price);
        }
    }
