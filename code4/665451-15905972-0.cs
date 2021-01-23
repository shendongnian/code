    public class People
    {
        public string Name { get; set; }
        public bool Disabled { get; set; }
        public string Hometown { get; set; }
        Hometown referenceToHometown;
    // default constructor
    public People()
    {
        name = "";
        disabled = false;
        hometown = "";
    }
    public People(string name, bool disabled, string hometown)
    {
        this.Name = name;
        this.Disabled = disabled;
        this.Hometown = hometown
    }
