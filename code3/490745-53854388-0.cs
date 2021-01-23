        public bool UserMustChangePasswordNextLogon
        {
            get
            {
                return (_userPrincipal.LastPasswordSet == null);
            }
            set
            {
                if (value)
                    _userPrincipal.ExpirePasswordNow();
                else
                    _userPrincipal.RefreshExpiredPassword();
            }
        }
