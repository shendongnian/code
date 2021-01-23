    public class Car
    {
        public Guid Id { get; set; }
        public Collection<Car> Cars { get; set; }
        public bool IsDuplicate
        {
            get
            {
                // Logic to check current car against a list of cars
                return (Cars.Count(c => c.Id.Equals(this.Id))) > 1;
            }
        }    
    }
