        public virtual int RoleNumber
        {
            get
            {
                if (this.IsInRole("Super")) return 30;
                if (this.IsInRole("Admin")) return 20;
                if (this.IsInRole("Guest")) return 10;
                return 5;
            }
        }
