    public interface ICar
    {
        void ShiftGearUp();
        void ShiftGearDown();
        void SwitchLightsOn();
        void SwitchLightsOff();
        void Brake();
        void Accelerate();
    }
    public class Car : ICar
    {
        public virtual void ShiftGearUp() { }
        public virtual void ShiftGearDown() { }
        public virtual void SwitchLightsOn() { }
        public virtual void SwitchLightsOff() { }
        public virtual void Brake() { }
        public virtual void Accelerate() { }
    }
    public class DeluxeCar : Car
    {
        public override void SwitchLightsOn()
        {
            //calls the implementation in the Car class.
            base.SwitchLightsOn();
            //implement custom behavior.
            this.AdjustCabinAmbientLighting();
        }
        private void AdjustCabinAmbientLighting() { }
    }
