        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !(obj is FTSdocWord)) return false;
            FTSdocWord item = (FTSdocWord)obj;
            return (OjbID == item.ObjID && VerID == item.VerID);
        }
        public override int GetHashCode()
        {
            return ObjID ^ VerID;
        }
