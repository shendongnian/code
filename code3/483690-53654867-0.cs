		public static JObject FindDiff(this JToken Current, JToken Model)
		{
			var diff = new JObject();
			if (JToken.DeepEquals(Current, Model)) return diff;
			switch(Current.Type)
			{
				case JTokenType.Object:
					{
						var current = Current as JObject;
						var model = Model as JObject;
						var addedKeys = current.Properties().Select(c => c.Name).Except(model.Properties().Select(c => c.Name));
						var removedKeys = model.Properties().Select(c => c.Name).Except(current.Properties().Select(c => c.Name));
						var unchangedKeys = current.Properties().Where(c => JToken.DeepEquals(c.Value, Model[c.Name])).Select(c => c.Name);
						foreach (var k in addedKeys)
						{
							diff[k] = new JObject
							{
								["+"] = Current[k]
							};
						}
						foreach (var k in removedKeys)
						{
							diff[k] = new JObject
							{
								["-"] = Model[k]
							};
						}
						var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys).Except(unchangedKeys);
						foreach (var k in potentiallyModifiedKeys)
						{
							diff[k] = FindDiff(current[k], model[k]);
						}
					}
					break;
				case JTokenType.Array:
					{
						var current = Current as JArray;
						var model = Model as JArray;
						diff["+"] = new JArray(current.Except(model));
						diff["-"] = new JArray(model.Except(current));
					}
					break;
				default:
					diff["+"] = Current;
					diff["-"] = Model;
					break;
			}
			return diff;
		}
