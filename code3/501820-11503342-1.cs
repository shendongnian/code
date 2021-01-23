    public class Foo(){
        public string Id { get; set; }
        public string Name { get; set; }
    }
     var ds = new List<Foo>(){
         new Foo { Id = "1", Name = "name1" },
         new Foo { Id = "2", Name = "name2" },
         new Foo { Id = "3", Name = "name3" },
         new Foo { Id = "4", Name = "name4" },
     };
     IndiaState.Add("WB");
     comboboxName.DataSource = ds;
     comboboxName.ValueMember = "Id";
     comboboxName.DisplayMember = "Name";
