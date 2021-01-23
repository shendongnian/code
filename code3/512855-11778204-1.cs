	private BlaNode(Node Previous, Node Next) : base(Previous, Previous)
	{
		//whatever you do
	}
	public static BlaNode BlaNodeFactory()
	{
		return new BlaNode(null, null);
	}
	public static BlaNode BlaNodeFactory(Node Previous, Node Next, string Bla)
	{
		return new BlaNode(Previous, Previous);
	}
