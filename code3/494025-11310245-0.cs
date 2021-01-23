    public abstract class Vehicle
    {
        protected List<string> canDo;
        protected Vehicle(List<string> canDo)
        {
            this.canDo = canDo;
        }
    }
    public class Plane : Vehicle
    {
        public Plane(List<string> canDo) : base(canDo)
        {
        }
    }
