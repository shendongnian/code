    [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [System.Web.Services.WebMethod]
        public static List<Emp> GetJson()
        {
            List<Emp> empTreeArray = new List<Emp>();
    
            Emp emp1 = new Emp()
            {
                attr = new EmpAttribute(){ id= "25",selected=false},
                data = "Nitin-Gurgaon"
            };
    
            Emp emp2 = new Emp()
            {
                attr =  new EmpAttribute(){ id="50",selected=false},
                data = "Sachin-Noida"
            };
            empTreeArray.Add(emp1);
            empTreeArray.Add(emp2);
            return empTreeArray;
        }
