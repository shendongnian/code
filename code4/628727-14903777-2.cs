    public class CustomerTypeDAL: DALBaseCache<CustomerType>
    {
    	protected override List<CustomerType> GetItemList()
    	{
    		DBEntities entities = new DBEntities();
    		return Mapper.Map <List<CustomerType>>(entities.GetAllCustomerTypes().ToList());
    	}
    }
