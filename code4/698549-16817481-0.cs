    public class Saturn
    {
        private int masa;
        public Saturn() { masa = 0; }
    }
    public class SolarSystem {
        private Saturn saturn;
        public SolarSystem(Saturn saturn)
        {
            this.saturn = saturn;
        }
    }
