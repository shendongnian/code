    Assembly asm = Assembly.LoadFrom("generated_asm.dll");
    // or if the assembly is already loaded:
    // asm = AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "Generated.Assembly");
    
    var type = asm.GetType("InsertNamespaceHere.InsertTypeNameHere");
    // creates a table layout which you can add to a form (preferable you use the designer to create this)
    var tbl = new TableLayoutPanel { ColumnCount = 2 };
    // enumerate the public properties of the type
    foreach(var property in type.GetProperties())
    {
      tbl.Add(new Label(property.Name));
      var input = new TextBox { Tag = property };
      input.TextChanged = this.HandleTextChanged;
      input.Enabled = property.CanWrite;
      tbl.Add(input);
    }
