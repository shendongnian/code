    public class MyForeignKeyDiscoveryConvention : ForeignKeyDiscoveryConvention
    {
        protected override bool MatchDependentKeyProperty(AssociationType associationType, AssociationEndMember dependentAssociationEnd,
            EdmProperty dependentProperty, EntityType principalEntityType, EdmProperty principalKeyProperty)
        {
            // The standard foreign key property to look for is TableName_Id. Use the below line to look for TableNameId instead.
            //return dependentProperty.Name == principalEntityType.Name + "Id";
            
            // Use the following for the IdKotaLahir scenario
            string navigationPropertyName = ((System.Reflection.PropertyInfo)dependentAssociationEnd.MetadataProperties.GetValue("ClrPropertyInfo", false).Value).Name;
            return dependentProperty.Name == "Id" + navigationPropertyName;
        }
    }
