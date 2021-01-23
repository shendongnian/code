    public class SwimBehavior: ISwimBehavior
    {
        public void Swim()
        {
            //do something to swim
        }
    }
    public class EletricSwimBehavior: ISwimBehavior
    {
        public void Swim()
        {
            if (!IsTurnedOn)
                this.TurnOn();
            //do something to swim
        }
        public void TurnOn()
        {
            this.IsTurnedOn = true;
        }
        public bool IsTurnedOn { get; set; }
    }
