    var model = _svc.GetList(q =>  
         (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(q.Name) 
           || q.Name.ToLower().Contains(entity.Name.ToLower()))
     && (string.IsNullOrEmpty(entity. Description) || string.IsNullOrEmpty(q. Description) 
           || q.Description.ToLower().Contains(entity. Description.ToLower())))
