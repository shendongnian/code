        public dynamic AsJson()
        {
            return new
            {
               name = this.Name,
               membersCount = this.Members.Count()
            }
        }
