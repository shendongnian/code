    public class ComboBoxItem
    {
        public string Display { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return this.Display;
        }
    }
