    protected void FillEntityMetadata(BaseEntity entity, bool isUpdate = false)
    {
      // Set audit data.
      if (!isUpdate)
      {
        entity.CreatedBy = CurrentUser.ID;
        entity.CreatedOn = DateTime.Now;
        entity.IsActive = true;
      }
      entity.LastModifiedBy = CurrentUser.ID;
      entity.LastModifiedOn = DateTime.Now;
    }
