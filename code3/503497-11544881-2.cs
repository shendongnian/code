    public bool Authorize(string controllerName, string actionName) {
    
                bool authorize = false;
    
                foreach(var permission in this.permissions) {
                    if (permission.Matches(controllerName, actionName)) {
                        authorize = permission.Affirmative;
                    }
                }
    
                return authorize;
            }
