      public List<string> Combolist {get;set}
      //ctor
      this.Combolist = new List<string>();
      while (reader.Read())
            {
                Combolist .Add(reader.GetString(0));
            }
      this.DataContext = this;
