    //Sensor.cs
    public class Sensor
    {
        public string Ip{ get; set; }
        public string Port{ get; set; }
        public string PhysicalLocation{ get; set }
    
        public Sensor(string ipAddr, string portNum, string loc)
        {
            Ip= ipAddr;
            Port= portNum;
            PhysicalLocation= loc;
        }
    }
    
    //SensorCollection.cs
    public class SensorCollection
    {
        private List<Sensor> sensors;
    
        public Sensor this[int i]
        {
            get { return this.sensors[i]; }
            set { this.sensors[i] = value; }
        }
    
        public IEnumerable<Sensor> Sensors
        {
            get{ return this.sensors; }
        }
        public SensorCollection()
        {
            sensors = new List<Sensor>();
        }
    
        public SensorCollection(string ip, string port, string location) : this()
        {
            this.sensors.Add(new Sensor(ip, port, location));
        }
    
        public SensorCollection(Sensor sensor) : this()
        {
            this.sensors.Add(sensor);
        }
        public void AddSensor(Sensor sensor)
        {
            //Determine whether or not to add it
            this.sensors.Add(sensor);
        }
    
        public void RemoveSensor(Sensor sensor)
        {
            if (sensors.Contains(sensor))
                sensors.Remove(sensor);
        }
    }
