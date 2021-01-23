	private BlaNode(Node Previous, Node Next) : base(Previous, Previous)
	{
		//whatever you do
	}
	public static BlaNodeFactory()
	{
		return new BlaNode(null, null);
	}
	public static BlaNodeFactory(Node Previous, Node Next, string Bla)
	{
		return new BlaNode(Previous, Previous);
	}
