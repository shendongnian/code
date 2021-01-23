    class Mommy : Grandma
    {
        public override void Mtd()
        { 
            base.Mtd();   // calls `Grandma` implementation
            if (this.GetType() == typeof(Mommy))
            {
                // not executed for any derived class
            }
            if (!(this is Daughter))
            {
                // not executed for `Daughter`
            }
        }        
    }
    class Daughter : Mommy
    {
        public override void Mtd()
        { 
            base.Mtd();   // calls `Mommy` implementation
        }
    }
