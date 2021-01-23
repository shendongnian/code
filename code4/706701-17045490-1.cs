    combinedCol = (from mapCol in DirectoryMappingsCollection.ToList()
                   join propCol in DirectoryProfilePropertiesCollection
                   on mapCol.DirectoryAttribute equals propCol.Key
                   select new CombinedMappingDataCollection
                   {
                       DetailName = mapCol.DetailRequirement.DetailName,
                       AttributeName = propCol.Key,
                       AttributeValue = propCol.Value
                   }).ToList();
