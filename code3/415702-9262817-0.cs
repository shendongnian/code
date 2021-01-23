    static public int assaultToHit(int _attacker_WeaponSkill,
            int _defender_WeaponSkill)
        {
            //Preconditions
            if(!(_attacker_WeaponSkill >= 1 && _attacker_WeaponSkill <= 10))
            {
                throw new ArgumentOutOfRangeException("Attackers WeaponSkill must be in range [1,10]");
            }
            if(!(_defender_WeaponSkill >= 1 && _defender_WeaponSkill <= 10))
            {
                throw new ArgumentOutOfRangeException("Defenders WeaponSkill must be in range [1,10]");
            }
            ...
            //rest unchanged
        }
