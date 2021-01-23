    var anonymous = db.SomeObject.Where( x => x.Id == someObjectId )
      .Select( x => new
        {
          SomeObject = x,
          Tasks = x.Tasks
            .Where( o => !o.IsDeleted )
            .OrderBy( o => ... )
        }
      )
      .SingleOrDefault()
    ;
