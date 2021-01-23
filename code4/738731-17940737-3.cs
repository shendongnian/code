    public interface ICar
    {
        void ShiftGearUp();
        void ShiftGearDown();
        void SwitchLightsOn();
        void SwitchLightsOff();
        void Brake();
        void Accelerate();
    }
    public abstract class AbstractCar : ICar
    {
        protected ITransmission Transmission;
        protected ILights Lights;
        protected IEngine Engine;
        protected IBrakes Brakes;
        public void ShiftGearUp()
        {
            this.Transmission.ShiftUp();
        }
        public void ShiftGearDown()
        {
            this.Transmission.ShiftDown();
        }
        public void SwitchLightsOn()
        {
            this.Lights.SwitchOn();
        }
        public void SwitchLightsOff()
        {
            this.Lights.SwitchOff();
        }
        public void Brake()
        {
            this.Brakes.Brake();
        }
        public void Accelerate()
        {
            this.Engine.Accelerate();
        }
    }
    public class Car : AbstractCar
    {
        public Car()
        {
            this.Lights = new AcmeLights();
            //todo
            //this.Engine = init engine object;
            //this.Brakes = init brakes object;
            //this.Transmission = init transmission object;
        }
    }
    public class DeluxeCar : AbstractCar
    {
        public DeluxeCar()
        {
            this.Lights = new FancyLights();
            //todo
            //this.Engine = init engine object;
            //this.Brakes = init brakes object;
            //this.Transmission = init transmission object;
        }
    }
    public interface ITransmission
    {
        void ShiftUp();
        void ShiftDown();
    }
    public interface ILights
    {
        void SwitchOn();
        void SwitchOff();
    }
    public interface IEngine
    {
        void Accelerate();
    }
    public interface IBrakes
    {
        void Brake();
    }
    public class AcmeLights : ILights
    {
        private LightSwitch Switch;
        public void SwitchOn() { this.Switch.On(); }
        public void SwitchOff() { this.Switch.Off(); }
    }
    public class FancyLights : ILights
    {
        private LightSwitch Switch;
        private CabinAmbientLightingController AmbientLightingController;
        public void SwitchOn()
        {
            this.Switch.On();
            this.AmbientLightingController.AdjustLightLevel();
        }
        public void SwitchOff()
        {
            this.Switch.Off();
            this.AmbientLightingController.AdjustLightLevel();
        }
    }
    public class LightSwitch
    {
        public void On() { }
        public void Off() { }
    }
    public class CabinAmbientLightingController
    {
        public void AdjustLightLevel() { }
    }
