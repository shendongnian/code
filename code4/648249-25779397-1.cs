	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Infrastructure.Annotations;
	using System.Data.Entity.ModelConfiguration.Configuration;
	internal static class TypeConfigurationExtensions
	{
		public static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(
			this PrimitivePropertyConfiguration property, 
			string indexName,
			int columnOrder = 0)
		{
			var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = true };
			var indexAnnotation = new IndexAnnotation(indexAttribute);
			return property.HasColumnAnnotation("Index", indexAnnotation);
		}
	}
