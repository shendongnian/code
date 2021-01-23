    public Collection<Class> Classes
    {
      get;
      set;
    }
     
    public MainWindow()
    {
      this.InitializeComponent( );
      this.Classes = new Collection<Class>( )
      {
        new Class("Class 1",
          new Collection<Student>()
          {new Student("Caba", "Milagros"),
            new Student("Wiltse","Julio"),
            new Student("Clinard","Saundra")}),
        
        new Class("Class 2",
          new Collection<Student>()
          {new Student("Cossette", "Liza"),
            new Student("Linebaugh","Althea"),
            new Student("Bickle","Kurt")}),
        
        new Class("Class 3",
          new Collection<Student>()
          {new Student("Selden", "Allan"),
            new Student("Kuo","Ericka"),
            new Student("Cobbley","Tia")}),
      };
      this.DataContext = this;
		}
