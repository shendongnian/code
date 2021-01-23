    public partial class EntityContext
    {
        public List<Plant> GetAllCusomters()
        {
            return Customers.ToList();
        }
        
    }
