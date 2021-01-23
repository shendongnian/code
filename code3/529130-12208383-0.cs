    enum Potion
    {
        Health,
        Mana
    }
    
    class PotionBag
    {
        readonly int[] _potions = new int[Enum.GetValues(typeof(Potion)).Length];
    
        public void Add(Potion potion)
        {
            _potions[(int)potion]++;
        }
    
        public void Use(Potion potion)
        {
            if (GetCount(potion) == 0)
                throw new InvalidOperationException();
            _potions[(int)potion]--;
        }
    
        public int GetCount(Potion potion)
        {
            return _potions[(int)potion];
        }
    }
