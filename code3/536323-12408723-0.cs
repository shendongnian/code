    public class Person
    {
      public string Name { get; set; }
      public string EmpId { get; set; }
    }
    public MainForm()
    {
      InitializeComponent();
      // bind column to property of person
      empName.DataPropertyName = "Name";
      empId.DataPropertyName = "EmpId";
      // set our bindinglist of persons as datasource
      var bindingList = new BindingList<Person>();
      bindingList.Add(new Person(){ Name = "John", EmpId = "12345" });
      bindingList.Add(new Person(){ Name = "David", EmpId = "12346" });
      dgAttendanceLog.DataSource = bindingList;
    }
