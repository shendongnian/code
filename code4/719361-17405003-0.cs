    public void UpdateSingle<T>(T item) where T : class
    {
        // If entity is Sortable, update the indexes of the records between the new and the old index of the updated entity
        var sortable = item as ISortable;
        if (sortable != null)
        {
            Detach(item);   // need to detach the entity from the context in order to retrieve the old values from DB
            var oldItem = Find<T>(sortable.Id) as ISortable;
    
            if (oldItem != null && sortable.Idx != oldItem.Idx)
            {
                UpdateSingleSortable(oldItem);
            }
            Detach(oldItem);
            Attach(item);   // re-attach to enable saving
        }
    
        Entry(item).State = EntityState.Modified;
    
        Commit();
    }
    public void UpdateSingleSortable<T>(T oldItem, T sortable)
        where T : ISortable
    {
            var entities = FindAll<T>();
            var oldIdx = oldItem.Idx;
            var newIdx = sortable.Idx;
            if (newIdx > oldIdx)
            {
                var toUpdate = entities.Where(a => a.Idx <= newIdx && a.Idx > oldIdx).Select(a => a);
                foreach (var toUpdateEntity in toUpdate)
                {
                    toUpdateEntity.Idx = toUpdateEntity.Idx - 1;
                }
            }
            else
            {
                var toUpdate = entities.Where(a => a.Idx >= newIdx && a.Idx < oldIdx).Select(a => a);
                foreach (var toUpdateEntity in toUpdate)
                {
                    toUpdateEntity.Idx = toUpdateEntity.Idx + 1;
                }
            }
    }
