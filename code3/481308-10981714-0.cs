        public override bool Equals(object obj)
        {
            if (obj is MyPhoto)
            {
                var objPhoto = obj as MyPhoto;
                if (objPhoto.Duid == this.Duid)
                    return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Duid.GetHashCode();
        }
