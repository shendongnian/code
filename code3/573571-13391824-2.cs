    enum Outcomes { Crit, DoubleCrit, FireDMG, Burn, NoEffect }
    
    abstract class Attack 
    { 
        public Attack() { Child = null; }
    
        List<Outcomes> GetOutcomes(); 
        protected virtual Attack Child; 
    }
    class Melee : Attack 
    { 
        public Melee() : base() { }
        public Melee(Attack child) : base() { Child = child; }
    
        List<Outcomes> GetOutcomes()
        {
            List<Outcomes> ret = new List<Outcomes>();
            if(Child != null) ret.Add(Child.GetOutcomes());
            
            if(ret.Contains(Outcomes.Crit))
                ret.Add(Outcomes.DoubleCrit);
            else
                ret.Add(Outcomes.Crit);
    
            return ret;
        }
    }
    class Fire : Attack 
    { 
        public Fire() : base() { }
        public Fire(Attack child) : base() { Child = child; }
    
        List<Outcomes> GetOutcomes()
        {
            List<Outcomes> ret = new List<Outcomes>();
            if(Child != null) ret.Add(Child.GetOutcomes());
            
            List<Outcomes> PossibleOutcomes = new List<Outcomes>();        
    
            PossibleOutcomes.Add(Outcomes.FireDMG);
            PossibleOutcomes.Add(Outcomes.Burn);
    
            if(ret.Contains(Outcomes.Burn)) PossibleOutcomes.Add(Outcomes.Fireball)
            if(ret.Contains(Outcomes.FireDMG)) PossibleOutcomes.Add(Outcomes.NoEffect);
    
            // Use some randomization method to select an item from PossibleOutcomes
            int rnd = 2; // Totally random number.
            ret.Add(PossibleOutcomes[rnd]);
            return ret;
        }
    }
