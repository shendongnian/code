    public class Elf : IAttackable
    {
        public void ReduceHealth(int amount)
        {
            this.Health -= amount;
        }
    }
