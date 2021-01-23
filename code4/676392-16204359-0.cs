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
        public string Id { get; set; }
        public int WeightInOunces { get; set; }
        public decimal DeliveryCost { get; set; }
        public Person Sender { get; set; }
        public Person Recipient { get; set; }
        protected double CostPerOunce { get; set; }
        protected virtual double CalculateCost ()
        {
            return WeightInOunces*CostPerOunce;
        }
    }
    public class OvernightPackage : Package
    {
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
        public double TotalCost
        {
            get
            {
                return Packages.Sum(package => (double) package.DeliveryCost);
            }
        }
    }
