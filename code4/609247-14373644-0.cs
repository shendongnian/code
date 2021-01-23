    public class Car  
        {
            public string Name { get; set; }
            public int Velocity { get; set; }
    
            public Car(string name)
            {
                this.Name = name;
                Console.WriteLine("\nCreated a {0}", name);
                Console.WriteLine("Velocity is {0}", this.Velocity);
            }
    
            public void Accelerate()
            {
                this.Velocity++;
                Console.WriteLine("Accelerated {0} to velocity {1}",
                    this.Name, this.Velocity);
            }
        }
