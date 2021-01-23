    public GridItem[] Items
        {
            get
            {
                try
                {
                    System.Reflection.FieldInfo field_gridView = typeof(PropertyGrid).GetField("gridView", System.Reflection.BindingFlags.NonPublic
                        | System.Reflection.BindingFlags.Instance);
                    object gridView = field_gridView.GetValue(this);
                    System.Reflection.MethodInfo gridView_method_GetAllGridEntries = gridView.GetType().GetMethod("GetAllGridEntries", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new Type[0], null);
                    object gridEntries_collection = gridView_method_GetAllGridEntries.Invoke(gridView, new object[0]);
                    System.Reflection.MethodInfo gridEntries_collection_count_method = gridEntries_collection.GetType().GetMethod("get_Count");
                    int count_entries = (int) gridEntries_collection_count_method.Invoke(gridEntries_collection, new object[0]);
                    System.Reflection.MethodInfo gridEntries_collection_getItem_method = gridEntries_collection.GetType().GetMethod("get_Item", new Type[] { typeof(int) });
                    GridItem[] entries = new GridItem[count_entries];
                    for (int i = 0; i < count_entries; i++)
                    {
                        entries[i] = gridEntries_collection_getItem_method.Invoke(gridEntries_collection, new object[] { i }) as GridItem;
                    }
                    return entries;
                }
                catch
                {
                    throw;
                }
            }
        }
