    private object _lockHandle=new object();
    
     public override string[] GetRolesForUser(string username)
        {
    lock(_lockHandle){
            return _roleRepository.GetRolesForUser(username);
    }
        }
