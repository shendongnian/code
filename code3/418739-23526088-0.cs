    public class OuterModel 
    {
        public OuterModel ()
        {
            AuxData= new InnerModel();
        }
        public InnerModel AuxData{ get; set; }
    }
    public class InnerModel
    {
         Int Id {get; set;}
    }
