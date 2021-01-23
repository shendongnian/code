        public virtual List<Impersonation> UserImpersonations
        {
            get
            {
                if(_userImpersonations == null)
                {
                // Set _userImpersonations = 
                // lazy load using a linq to sql query where 
                // UserImpersonations.UserId = this.UserId
                }
                return __userImpersonations;
            }
        }
