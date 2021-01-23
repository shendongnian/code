        public override int GetHashCode()
        {
            unchecked
            {
                int result = (SomeStrId != null ? SomeStrId.GetHashCode() : 0);
                result = (result*397) ^ (Desc != null ? Desc.GetHashCode() : 0);
                result = (result*397) ^ (AnotherId != null ? AnotherId.GetHashCode() : 0);
                return result;
            }
        }
