        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !(obj is FTSdocWord)) return false;
            FTSdocWord item = (FTSdocWord)obj;
            return (WordID == item.WordID && CharPos == item.CharPos);
        }
        public override int GetHashCode()
        {
            return WordID ^ CharPos; ;
        }
