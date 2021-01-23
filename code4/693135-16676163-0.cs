    private void Test()
    {
        ContactDetail cd = new ContactDetail();
        cd.ContactTypeID = 1;
        cd.Value = "3";
        cd.Save();
        return cd.ContactDetailID;    
    }
    public ContactDetailDTO Save()
    {
        ContactDetailDAO service = new ContactDetailDAO();
        ContactDetailDTO saveItem = new ContactDetailDTO();
        if (IsValid(this))
        {
            saveItem.ContactDetailID = this.ContactDetailID;
            saveItem.Value = this.Value;
            saveItem.ContactTypeID = this.ContactTypeID;
            saveItem=service.Save(saveItem);
            this.ContactDetailID = saveItem.ContactDetailID;
        }
        return saveItem; 
    }
    public ContactDetailDTO Save(ContactDetailDTO ContactDetailDTO)
    {
        if (ContactDetailDTO.IsNew())
        {
            return repository.Add(new tblContactDetail
            {
                ContactDetailID = ContactDetailDTO.ContactDetailID,
                Value = ContactDetailDTO.Value,
                ContactTypeID = ContactDetailDTO.ContactTypeID
            });
        }
    }
    public virtual T Add(T entity)
    {
        context.Entry(entity).State = System.Data.EntityState.Added;
        if (entity == null)
        {
            throw new ArgumentException("Cannot add a null entity.");
        }
        this.context.Set<T>().Add(entity);
        this.context.SaveChanges();
        return entity;
    }
