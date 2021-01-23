    var data = (from a in Table.AsEnumerable()
                 select new ValueHolder
                 {
                     Name = a.Field<string>("Colour")
                 }).Distinct().OrderBy(p => p.Name).ToList(); 
    
    var column = new DataGridViewComboBoxColumn();      
    column.DataSource = data; 
    column.ValueMember = "Name"; 
    column.DisplayMember = "Name"; 
    
    dataGridView1.Columns.Add(column); 
    
//------------------------------------------------------------
    
    class ValueHolder
    {
      public string Name{get;set;}
    
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
