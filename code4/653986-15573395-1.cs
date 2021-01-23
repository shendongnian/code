    // choose from existng:
    var data = (from a in Table.AsEnumerable()
                 select new ValueHolder
                 {
                     Name = a.Field<string>("Colour")
                 }).Distinct().OrderBy(p => p.Name).ToList(); 
    // your own
    var data = new List<ValueHolder>();
    data.Add(new ValueHolder("Red"));
    data.Add(new ValueHolder("Yellow"));
    //..................
    var column = new DataGridViewComboBoxColumn();      
    column.DataSource = data; 
    column.ValueMember = "Name"; 
    column.DisplayMember = "Name"; 
    
    dataGridView1.Columns.Add(column); 
    
//------------------------------------------------------------
    
    class ValueHolder
    {
      public string Name{get;set;}
       public ValueHolder(string name)
       {
         this.Name = name;
       }
      // this part may not be necessary without nulls:
      //public override bool Equals(object obj)
      //      {
      //          ValueHolder other = obj as ValueHolder;
      //          if (other.Name.Equals(this.Name)) return true;
      //          return false;
      //      }
    
      //      public override int GetHashCode()
      //      {
      //          return Name == null ? 0 : Name.GetHashCode();
      //      } 
    }
