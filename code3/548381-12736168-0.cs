    namespace Tests_CSharp_Indexer
    {
    class Elevator
    {
    }
    class Building
    {
        public class ElevatorList
        {
            private List<Elevator> elevators = new List<Elevator>();
            public Elevator this[int i]
            {
                get
                {
                    return elevators[i];
                }
                set
                {
                    if (i == elevators.Count)
                    {
                        elevators.Add(value);
                    }
                    else
                    {
                        elevators[i] = value;
                    }
                }
            }
            public int Count {
                get
                {
                    return elevators.Count;
                }
            }
        }
        public readonly ElevatorList Elevators = new ElevatorList();
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Building building = new Building();
            building.Elevators[0] = new Elevator();
            building.Elevators[1] = new Elevator();
            building.Elevators[2] = new Elevator();
            Console.Out.WriteLine(building.Elevators.Count);
        }
    }
    }
