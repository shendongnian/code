    public class BattlePlan
    {
        public Action<Puppy> ExecutePuppyAttack { get; set; }
        public Action<Pigeon> ExecutePigeonAttack { get; set; }
    }
    public abstract class Animal
    {
        public abstract void Attack(BattlePlan battlePlan);
    }
    public class Puppy : Animal
    {
        public void Bite(bool barkFirst)
        {
            // optionally bark at the intruder,
            // then bite as deeply as needed.
        }
        public override void Attack(BattlePlan battlePlan)
        {
            battlePlan.ExecutePuppyAttack(this);
        }
    }
    public class Pigeon : Animal
    {
        public void Bombard(int altitude)
        {
            // ewww. nuff said.
        }
        public override void Attack(BattlePlan battlePlan)
        {
            battlePlan.ExecutePigeonAttack(this);
        }
    }
    public class EvilMasterMind
    {
        private bool _puppiesMustBark = true;
        private int _pigeonAltitude = 100;
        public void Attack()
        {
            var battlePlan = new BattlePlan
            {
                ExecutePuppyAttack = e => e.Bite(_puppiesMustBark),
                ExecutePigeonAttack = e => e.Bombard(_pigeonAltitude)
            };
            var animals = new List<Animal>
            {
                new Puppy(),
                new Pigeon()
            };
            foreach (var animal in animals)
            {
                animal.Attack(battlePlan);
            }
        }
    }
