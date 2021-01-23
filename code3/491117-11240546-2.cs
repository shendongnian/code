    //Child 1
    class Child1 : ReportBase<GetChild1>
    {
       public ReportBase(DbContext context):base(context)
       {
            
       }
        
       public List<GetChild1> FilterOnStartDate(DateTime startDate)
       {
            //I don't know if you are familiar with lambda expressions but if you are not you can research it on the internet.
            //The parameter here is converted into a method that its parameter is "p" of type GetChild1
            // and the body is "p.UploadDate < startDate".
            // Note you can remove the type of the parameter because the compiler can predict it.
            return Filter((GetChild1 p) => p.UploadDate < startDate).ToList();
       }
    } 
