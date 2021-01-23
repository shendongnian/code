    public class House
    {
        public House(string number)
        {
            Number = number;
            Windows = new List<Window>();
        }
        public string Number { get; private set; }
        public List<Window> Windows { get; private set; }
        public House WithWindow(string size, string color, bool energySaving = false)
        {
            Windows.Add(new Window(size, color, energySaving));
            return this;
        }
    }
