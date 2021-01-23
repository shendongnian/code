        // This needs to be placed in a public static class and it's namespace added as a using to whatever class you'd like to use it in
		/// <summary>
		/// Returns the Aliased Value for a column specified in a Linked entity
		/// </summary>
		/// <typeparam name="T">The type of the aliased attribute form the linked entity</typeparam>
		/// <param name="entity"></param>
		/// <param name="attributeName">The aliased attribute from the linked entity.  Can be preappeneded with the
		/// linked entities logical name and a period. ie "Contact.LastName"</param>
		/// <returns></returns>
		public static T GetAliasedValue<T>(this Entity entity, string attributeName)
		{
			string aliasedEntityName = SplitAliasedAttributeEntityName(ref attributeName);
			AliasedValue aliased;
			foreach (var attribute in entity.Attributes.Values)
			{
				aliased = attribute as AliasedValue;
				if(entity.IsAttributeAliasedValue(attributeName, aliasedEntityName, aliased))
				{
					try
					{
						return (T)aliased.Value;
					}
					catch (InvalidCastException)
					{
						throw new InvalidCastException(
							String.Format("Unable to cast attribute {0}.{1} from type {2} to type {3}",
									aliased.EntityLogicalName, aliased.AttributeLogicalName,
									typeof(T).Name, aliased.Value.GetType().Name));
					}
				}
			}
			throw new Exception("Aliased value with attribute " + attributeName +
				" was not found!  Only these attributes were found: " + String.Join(", ", entity.Attributes.Keys));
		}
		/// <summary>
		/// Returns the Aliased Value for a column specified in a Linked entity, returning the default value for 
		/// the type if it wasn't found
		/// </summary>
		/// <typeparam name="T">The type of the aliased attribute form the linked entity</typeparam>
		/// <param name="entity"></param>
		/// <param name="attributeName">The aliased attribute from the linked entity.  Can be preappeneded with the
		/// linked entities logical name and a period. ie "Contact.LastName"</param>
		/// <returns></returns>
		public static T GetAliasedValueOrDefault<T>(this Entity entity, string attributeName)
		{
			T value;
			if (entity.HasAliasedAttribute(attributeName))
			{
				value = entity.GetAliasedValue<T>(attributeName);
			}
			else
			{
				value = default(T);
			}
			return value;
		}
		private static bool IsAttributeAliasedValue(this Entity entity, string attributeName, string aliasedEntityName, AliasedValue aliased)
		{
			bool value =
		   (aliased != null &&
				(aliasedEntityName == null || aliasedEntityName == aliased.EntityLogicalName) &&
				aliased.AttributeLogicalName == attributeName);
			
			/// I believe there is a bug in CRM 2011 when dealing with aggregate values of a linked entity in FetchXML.
			/// Even though it is marked with an alias, the AliasedValue in the Attribute collection will use the 
			/// actual CRM name, rather than the aliased one, even though the AttributeCollection's key will correctly
			/// use the aliased name.  So if the aliased Attribute Logical Name doesn't match the assumed attribute name
			/// value, check to see if the entity contains an AliasedValue with that key whose attribute logical name 
			/// doesn't match the key (the assumed bug), and mark it as being the aliased attribute
			if (!value && aliased != null && entity.Contains(attributeName))
			{
				var aliasedByKey = entity[attributeName] as AliasedValue;
				if (aliasedByKey != null && aliasedByKey.AttributeLogicalName != attributeName && 
					Object.ReferenceEquals(aliased, aliasedByKey))
				{
					value = true;
				}
			}
			return value;
		}
		
		/// <summary>
		/// Returns the Aliased Value for a column specified in a Linked entity
		/// </summary>
		/// <typeparam name="T">The type of the aliased attribute form the linked entity</typeparam>
		/// <param name="entity"></param>
		/// <param name="attributeName">The aliased attribute from the linked entity.  Can be preappeneded with the
		/// linked entities logical name and a period. ie "Contact.LastName"</param>
		/// <returns></returns>
		public static bool HasAliasedAttribute(this Entity entity, string attributeName)
		{
			string aliasedEntityName = SplitAliasedAttributeEntityName(ref attributeName);
			return entity.Attributes.Values.Any(a =>
				entity.IsAttributeAliasedValue(attributeName, aliasedEntityName, a as AliasedValue));
		}
		/// <summary>
		/// Handles spliting the attributeName if it is formated as "EntityAliasedName.AttributeName",
		/// updating the attribute name and returning the aliased EntityName
		/// </summary>
		/// <param name="attributeName"></param>
		/// <param name="aliasedEntityName"></param>
		private static string SplitAliasedAttributeEntityName(ref string attributeName)
		{
			string aliasedEntityName = null;
			if (attributeName.Contains('.'))
			{
				var split = attributeName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
				if (split.Length != 2)
				{
					throw new Exception("Attribute Name was specified for an Alaised Value with " + split.Length +
					" split parts, and two were expected.  Attribute Name = " + attributeName);
				}
				aliasedEntityName = split[0];
				attributeName = split[1];
			}
			return aliasedEntityName;
		}
