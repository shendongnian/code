    var permissionList=  (from per in _db.Permissions
                                                   select per).Distinct();
    
                foreach(var permission in permissionList)
                {
                    //something needs to be done abt this line
                    //var opert = Convert.ToInt32(Request.Form[name + "_op"]);
                    //var per=new Permission();
                    //per.Name=name;
                    //per.Operations=opert;
                    role.Permissions.Add(permission);
                }
