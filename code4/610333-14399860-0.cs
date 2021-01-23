    		protected String displayName(Object item)
			{
				String name = "";
				if (item != null && item.hasOwnProperty("name")) {
					name = item["name"];
				}
				return name;
			}
