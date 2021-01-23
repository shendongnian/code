	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DelimitedRecordAttribute : TypedRecordAttribute
	{
		internal string Separator;
	/// <summary>Indicates that this class represents a delimited record. </summary>
		/// <param name="delimiter">The separator string used to split the fields of the record.</param>
		public DelimitedRecordAttribute(string delimiter)
		{
			if (Separator != String.Empty)
				this.Separator = delimiter;
			else
				throw new ArgumentException("sep debe ser <> \"\"");
		}
	}
