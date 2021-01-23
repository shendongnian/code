	[ComVisible(true)]
	[Guid("F3071EE2-84C9-4347-A5FC-E72736FC441F")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProxy
	{
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)] 
		IOrder[] GetOrders();
	}
	[ComVisible(true)]
	[Guid("8B6EDB6B-2CF0-4eba-A756-B6E92A71A48B")]
	[ClassInterface(ClassInterfaceType.None)]
	public class Proxy : IProxy
	{
		public IOrder[] GetOrders() { return new[] {new Order(3), new Order(4)}; 		}
	}
	[ComVisible(true)]
	[Guid("CCFF9FE7-79E7-463c-B5CA-B1A497843333")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOrder
	{
		long GetQuantity();
	}
	[ComVisible(true)]
	[Guid("B0E866EB-AF6D-432c-9560-AFE7D171B0CE")]
	[ClassInterface(ClassInterfaceType.None)]
	public class Order : IOrder
	{
		private int m_quantity;
		public Order(int quantity) { m_quantity = quantity; }
		public long GetQuantity() { return m_quantity; }
	}
