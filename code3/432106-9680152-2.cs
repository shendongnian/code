    IQueryable<tbl> query = ent.tbl.Where(r => r.ID_Master == Id && r.Year == Year);
    //customize query
    if(IsDeleted != null){
      query = query.Where(r => r.IsDeleted == IsDeleted);
    }
    //execute the final generated query
    var result = query.FirstOrDefault();
