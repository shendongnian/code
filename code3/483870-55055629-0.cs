     class FutureVisitsModel
        {
            public DateTime StartDate {get; set;}
            public string Client_Id { get; set; }
            public string Treatment_Desc { get; set; }
            public string Service_Code { get; set; }
    
            public FutureVisitsModel()
            {
                DateTime startdate = StartDate;
                String clinetid = Client_Id;
                String treatmentdesc = Treatment_Desc;
                String serviceCode = Service_Code;
            }
        }
