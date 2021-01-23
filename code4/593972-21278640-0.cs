    /// <summary>
	/// Special contract resolver to create objects bypassing constructor call.
	/// </summary>
	public class NoConstructorCreationContractResolver : DefaultContractResolver
	{
		/// <summary>
		/// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract"/> for the given type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		/// A <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract"/> for the given type.
		/// </returns>
		protected override JsonObjectContract CreateObjectContract(Type objectType)
		{
			var objectContract = base.CreateObjectContract(objectType);
			// substitute creator function for non abstract classes if no constructor marked with JsonConstructor attribute
			if (objectContract.OverrideConstructor == null && objectContract.UnderlyingType.IsClass && !objectContract.UnderlyingType.IsAbstract)
			{
				objectContract.DefaultCreatorNonPublic = false;
				objectContract.DefaultCreator = () => FormatterServices.GetSafeUninitializedObject(objectContract.UnderlyingType);
			}
			return objectContract;
		}
	}
