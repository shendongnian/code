     protected IQueryable<EntityResult> GetEntities(ETBDataContext pContext)
    {
        return (from e in pContext.Entities
               where e.StatusCode == "Published"
               //is there a way to add a dynamic where clause here?
               //I would like to ask the inherited class for it's input:
               && e.OtherColumn == "OtherValue" // <-- like GetWhere(e)?
               //without having to select the column
               orderby e.PublishDate descending
               select e).FirstOrDefault();
    }
