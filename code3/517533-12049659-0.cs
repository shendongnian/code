        public override bool Equals(object obj)
        {
            if (this == obj) { 
            
                return true;
            } 
            if (GetType() != obj.GetType()) {
                return false;
            }
            if (Id != ((BaseObject)obj).Id)
            {
                return false;
            }
            
            return true;
        }
