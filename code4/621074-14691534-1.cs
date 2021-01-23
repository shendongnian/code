    interface IEnemy
    {
        void TakeDamage(int attackPower);
    }
    
    public Elf: IEnemy
    {
        // sample implementation
        public void TakeDamage(int attackPower)
        {
            this.Health -= attackPower - this.Defense;
        }
    }
    
    // later on use IEnemy, which is implemented by all enemy creatures
    void Attack(IEnemy theEnemy)
    {          
          theEnemy.TakeDamage(attack)
    }
