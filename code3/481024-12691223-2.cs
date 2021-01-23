    public sealed class DictionaryDoubleKeyed : Dictionary<UInt32, string>
    {   // used UInt32 as the key as it has a perfect hash
        // if most of the lookup is by word then swap
        public void Add(UInt16 ID, string Word)
        {
            if (this.ContainsValue(Word)) throw new ArgumentException();
            base.Add(ID, Word);
        }
        public UInt32 this[string Word]
        {   // this wil be O(n)
            get
            {
                return this.FirstOrDefault(x => x.Value == Word).Key;
            }
        } 
    }
