    class DataAccess
    {
        void UpdateEntity(Entity entity)
        {
            _entityAudit.UpdateAudit(entity, _currentUser);
        
            // your update logic
            var existing = _dataSet.SingleOrDefault(e => e.ID == entity.ID);
            ...
        }
    }
