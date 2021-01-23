    public class MyForeignKeyDiscoveryConvention : ForeignKeyDiscoveryConvention
    {
        protected override bool MatchDependentKeyProperty(AssociationType associationType, AssociationEndMember dependentAssociationEnd,
            EdmProperty dependentProperty, EntityType principalEntityType, EdmProperty principalKeyProperty)
        {
            string navigationPropertyName = ((System.Reflection.PropertyInfo)dependentAssociationEnd.MetadataProperties.GetValue("ClrPropertyInfo", false).Value).Name;
            // The standard foreign key property to look for is NavigationProperty_PrimaryKeyName (e.g. "TableName_Id"). 
            // Use the below line to remove that underscore.
            //return dependentProperty.Name == navigationPropertyName + principalKeyProperty.Name;
            // Use the following for the IdKotaLahir scenario
            return dependentProperty.Name == "Id" + navigationPropertyName;
        }
    }
