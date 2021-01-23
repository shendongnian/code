        int BaseDamage = 18; //a base damage of the item
        //the fact damage, i.e. sum of the base one and all the enchantments
        public int Damage    
        {
            get
            {
                int encDamage = 0;
                if (Enchantments.Any())
                    encDamage += Enchantments.Sum(e => e.Damage);
                return BaseDamage + encDamage;
            }
        }
