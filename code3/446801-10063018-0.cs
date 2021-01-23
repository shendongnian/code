    public class Item {
      string Name { get; set; }
      string Value { get; set; }
    }
    ComboBox box = new ComboBox();
    box.DisplayMember = "Name";
    box.ValueMember = "Value";
    box.DataSource = new [] { new Item() { "Test", "test" } };
