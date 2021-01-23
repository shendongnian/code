    public class Film
    {
        public string name { get; set; }
        public string year { get; set; }
    }
    var d = xmldoc.Descendants("film").Select(x => new Film { name = x.Attribute("name").Value, year = x.Attribute("year").Value });
    <TextBlock Text="{Binding name}" />
    <TextBlock Text="{Binding year}" />
