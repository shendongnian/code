    <#@ template language="C#" debug="true" hostspecific="true"#>
    <#@ include file="EF.Utility.CS.ttinclude"#>
    <#
    string inputFile = @"DomainModel.edmx";
    MetadataLoader loader = new MetadataLoader(this);
    EdmItemCollection ItemCollection = loader.CreateEdmItemCollection(inputFile);
    foreach (EntityType entity in ItemCollection.GetItems<EntityType>().OrderBy(e => e.Name))
    {
        foreach (NavigationProperty navProperty in entity.NavigationProperties)
        {
            AssociationType association = ItemCollection.GetItems<AssociationType>().Single(a => a.Name == navProperty.RelationshipType.Name);
            string fromEntity = association.ReferentialConstraints[0].FromRole.Name;
            string fromEntityField = association.ReferentialConstraints[0].FromProperties[0].Name;
            string toEntity = association.ReferentialConstraints[0].ToRole.Name;
            string toEntityField = association.ReferentialConstraints[0].ToProperties[0].Name;
        }
    }
    #>
