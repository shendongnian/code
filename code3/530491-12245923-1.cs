    DataTable dt = new DataTable();
    // I assumed that dt has some data
 
    Session["dataTable"] = dt; // Saving datatable to Session
    // Retrieving 
    DataTable dtt = (DataTable) Session["dataTable"]; // Cast it to DataTable
    int a = 43432;
    Session["a"] = a;
    // Retrieving 
    int aa = (int) Session["a"];
    // classes
      class MyClass
      {
        public int a { get; set; }
        public int b { get; set; }
      }
      protected void Page_Load(object sender, EventArgs e)
      {
        MyClass obj = new MyClass();
        obj.a = 5;
        obj.b = 20;
        Session["myclass"] = obj;  // Save the class object in Session
         // Retrieving 
          MyClass obj1 = new MyClass();
           obj1 = (MyClass) Session["myclass"]; // Remember casting the object
       }
   
