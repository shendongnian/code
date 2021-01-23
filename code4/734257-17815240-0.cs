    public class Boom
    {
        string Name { get; set; }
        string Address { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}{1}Address: {2}, Name, Environment.NewLine, Address);
        }
    }
