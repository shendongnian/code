	public class WalletTransaction
	{
		public string TransactionDateTime { get; private set; }
		public int TransactionID { get; private set; }
		public int Quantity { get; private set; }
		// More omitted for length
		// FACTORY METHOD (RECOMMENDED)
		public static WalletTransaction Create(XmlNode node)
		{
			return new WalletTransaction()
			{
				TransactionDateTime = node.Attributes["transactionDateTime"].Value,
				TransactionID = int.Parse(node.Attributes["transactionID"].Value),
				Quantity = int.Parse(node.Attributes["quantity"].Value)
			};
		}
		// CTOR METHOD
		public WalletTransaction(XmlNode node)
		{
			TransactionDateTime = node.Attributes["transactionDateTime"].Value;
			TransactionID = int.Parse(node.Attributes["transactionID"].Value);
			Quantity = int.Parse(node.Attributes["quantity"].Value);
		}
	}
