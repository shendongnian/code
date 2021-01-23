    foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
        BeginNamespace(code);
    #>
    (rest of class generation code here...)
