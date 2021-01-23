      public static ObservableCollection<Data> FromXml(String data)
    		{
    			ObservableCollection<Data> dataCollection = default(ObservableCollection<Data>);
    			try
    			{
    				XElement _items = XElement.Parse(dataCollection);
    				var items = _items.Elements("Item").Select(i
    					=>
    					new Data
    					{
    						Name = i.Element("Name").Value,
    						Selected = bool.Parse(i.Element("Selected").Value),
    						Type = i.Element("Type").Value,
    					}
    					).ToArray();
				if (items != null)
				{
					dataCollection = new ObservableCollection<Data>();
					foreach (var item in dataCollection)
					{
						dataCollection.Add(item);
					}
					return dataCollection;
				}
			}
			catch (Exception e)
			{
			}
			return null;
		}
