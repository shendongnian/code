    public class Car : ICar
    {
        public IDoor Door { get; set; }
        public Car()
            : this(new Door())
        {
        }
        public Car(IDoor door)
        {
            this.Door = door;
        }
    }
