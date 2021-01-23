          class Program
        {
            static void Main(string[] args)
            {
                //the array method
                var test = new Order();
                test.AddPackage(new OvernightPackage() { WeightInOunces = 10, Sender = new Person() { Name = "Sender"}, Recipient = new Person() {Name = "Recipient"}});
                test.AddPackage(new TwoDayPackage() { WeightInOunces = 16, Sender = new Person() { Name = "Sender" }, Recipient = new Person() { Name = "Recipient" } });
                test.AddPackage(new TwoDayPackage() { WeightInOunces = 10, Sender = new Person() { Name = "Sender" }, Recipient = new Person() { Name = "Recipient" } });
                test.PrintManifestsWithArray();
                
                //the list way
                test.Packages = new List<Package>(test.PackagesArray);
                test.PrintManifests();
    
    
                Console.ReadLine();
            }
        }
    
        public class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }
        }
    
        public class Address
        {
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
        }
    
        public abstract class Package
        {
            protected Package()
            {
                CostPerOunce = .08;
                WeightInOunces = 0;
            }
            public string Id { get; set; }
            public int WeightInOunces { get; set; }
            public double DeliveryCost { get { return CalculateCost(); } }
            public Person Sender { get; set; }
            public Person Recipient { get; set; }
            public double CostPerOunce { get; set; }
            protected virtual double CalculateCost ()
            {
                return WeightInOunces*CostPerOunce;
            }
        }
    
        public class OvernightPackage : Package
        {
            public OvernightPackage()
            {
                CostPerOunce = .12;
            }
            protected override double CalculateCost()
            {
                var cost = base.CalculateCost();
                cost += 1500.00;
                return cost;
            }
        }
    
        public class TwoDayPackage : Package
        {
            protected override double CalculateCost()
            {
                var cost = base.CalculateCost();
                cost += 500.00;
                return cost;
            }
        }
    
        public class Order
        {
            public List<Package> Packages { get; set; }
            public Package[] PackagesArray
            {
                get { return _thePackages; }
            }
            
            private Package[] _thePackages = new Package[0];
            public void AddPackage(Package pkg)
            {
                Array.Resize(ref _thePackages, _thePackages.Length + 1);
                _thePackages[_thePackages.Length -1] = pkg;
            }
    
            public void PrintManifestsWithArray()
            {
                foreach (var package in PackagesArray)
                {
                    Console.WriteLine( package.GetType() + ": " + package.DeliveryCost);
                }
            }
    
            public double TotalCost
            {
                get
                {
                    return Packages.Sum(package => (double) package.DeliveryCost);
                }
            }
    
            public void PrintManifests()
            {
                foreach (var package in Packages)
                {
                    Console.WriteLine(package.Sender.Name);
                    Console.WriteLine(package.Recipient.Name);
                    Console.WriteLine(package.DeliveryCost);
                    ///so on and so forth
                }
            }
        }
