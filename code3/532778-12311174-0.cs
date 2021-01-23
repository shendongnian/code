    public abstract class Vehicle
    {
        private MovementStrategy movementStrategy;
        protected Vehicle(MovementStrategy strategy)
        {
            this.movementStrategy = strategy;
        }
        public void Move()
        {
            movementStrategy.Move();
        }
        public virtual void CommonAlert()
        {
            Console.WriteLine("Base generic vehicle alert");
        }
    }
    public class Car : Vehicle
    {
        public Car(MovementStrategy movementStrategy)
            : base(movementStrategy)
        {
        }
        public override void CommonAlert()
        {
            Console.WriteLine("Car says 'Honk!'");
        }
    }
    public class Elevator : Vehicle
    {
        public Elevator(MovementStrategy movementStrategy)
            : base(movementStrategy)
        {
        }
        public override void CommonAlert()
        {
            Console.WriteLine("Elevator says 'Ding!'");
            base.CommonAlert();
        }
    }
    public abstract class MovementStrategy
    {
        public abstract void Move();
    }
    public class CarMovementStrategy : MovementStrategy
    {
        public override void Move()
        {
            Console.WriteLine("Car moved");
        }
    }
    public class ElevatorMovementStrategy : MovementStrategy
    {
        public override void Move()
        {
            Console.WriteLine("Elevator moved");
        }
    }
