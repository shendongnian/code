    public List<Person> AddressFinderBLL_GetAddressbyName(String pfname,)
    {
       List<Person> Per= new List<Person>();
       List<DataSet> lstPer = new List<DataSet>();
       lstPer = Adal.AddressFinderDAL_GenerateDatabyName(pfname, pfnameval, plname, plnameval);
       //here List<Dataset> lstPer loaded with values from back end 
    foreach(DataRow item in lstPer[0].Tables[0].Rows)
           {
                  // here i need to assign the values to List<Person> from List<Dataset>[0].tables[0].rows; 
              var p = new Person();
    //it isn't clear what structure item will have. let's assume that it has 2 columns. one is         //firstname and the other is last name 
              p.FirstName = item[0];
              p.Middlename = item[1];
              Per.Add(p);
           } 
