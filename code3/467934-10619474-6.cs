		public static String ToXml(ObservableCollection<Data> items)
		{
			try
			{
				XElement _items = new XElement("Root",
									from item in items()
									select new XElement("Item",
										new XElement("Name", item.OrderId),
										new XElement("Type", item.OrderType),
										new XElement("Selected", item.Security)
										)
										);
				return _items.ToString();
			}
			catch (Exception ex)
			{
			}
			return String.Empty;
		}
 
