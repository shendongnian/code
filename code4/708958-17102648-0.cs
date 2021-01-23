	public interface ISecuredEntity
	{
		IEnumerable<string> haspermissions { get; }
	}
	public class Address : ISecuredEntity
	{
		public IEnumerable<string> haspermissions { get; set; }
	}
	
	public class AddressRepository : SecureRepositoryBase<Address>, IAddressRepository
	{
		private AISDbContext context = new AISDbContext();
		public IQueryable<Address> GetAddresses()
		{
			return base.RetrieveSecure(context.Address, CURENTUSER);
		}
	}
	public abstract class SecureRepositoryBase<T>
		where T : ISecuredEntity
	{
		public IQueryable<T> RetrieveSecure(IQueryable<T> entities, IUser currentUser)
		{
			return entities.Where(e => e.Permissions.Contains(currentUser.Role));
		}
	}
