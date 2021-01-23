    class Mommy : Grandma
    {
        public override void Mtd()
        { 
            base.Mtd();   // calls `Grandma` implementation
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
