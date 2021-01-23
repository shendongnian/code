    using System;
	using System.ComponentModel;
	namespace AppResourceLib.Public.Reflection
	{
	  /// <summary>
	  /// A resource type attribute that can be applied to enumerations.
	  /// </summary>
	  [AttributeUsage(AttributeTargets.Enum)]
	  public sealed class LocalizedDescriptionAttribute : Attribute
	  {
		/// <summary>
		/// The type of resource associated with the enum type.
		/// </summary>
		private Type _resourceType;
		public LocalizedDescriptionAttribute(Type resourceType)
		{
		  this._resourceType = resourceType;
		}
		/// <summary>
		/// The type of resource associated with the enum type.
		/// </summary>
		public Type ResourceType
		{
		  get
		  {
			return this._resourceType;
		  }
		}
	  }
	}
