	var co = new chartObject()
	{
		name = "chartObject1",
		children = new List<chartObject>()
		{
			new chartObject()
			{
				name = "chartObject2",
				children = new List<chartObject>() { }
			},
			new chartObject()
			{
				name = "chartObject3",
				children = new List<chartObject>()
				{
					new chartObject()
					{
						name = "chartObject4",
						children = new List<chartObject>()
						{
							new chartObject()
							{
								name = "chartObject5",
								children = new List<chartObject>() { }
							}
						}
					}
				}
			}
		}
	};
