    case System.Data.EntityState.Modified:                        
        var originalEntity = trackedEntity.OriginalValues.ToObject() as ITrackable;
        originalEntity.ModifiedDate = now;
        originalEntity.ModifiedBy = currentUser;
        originalEntity.Status = Status.Modified;
        Entry(originalEntity).Status = System.Data.EntityState.Added;
        trackedEntity.Entity.Status = Status.Active;
        break;
