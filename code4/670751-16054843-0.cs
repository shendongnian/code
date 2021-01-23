    public class Messageformat {
      public MessageFormat() {
        Attributes = new Attributecollection();
        Input = new Input();
        Output = new output();
      }
      public Attributecollection Attributes { get; set; }
      public Input Input { get; set; }
      public output Output { get; set; }
    }
    public class Attributecollection {
      public string name { get; set; }
      public int id { get; set; }
    }
    public class Input {
      public string soid { get; set; }
      public string itemname { get; set; }
      public int qty { get; set; }
    }
    public class output {
      public string soid { get; set; }
    }
