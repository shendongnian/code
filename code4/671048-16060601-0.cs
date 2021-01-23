    public class DataIWantInAList
    {
        public IList<DataIWant> data;
        //Instanciation & Initialization
        public DataIWantInAList(params customparam)
        {
            using(EntitySet ent = new EntitySet())
            {
            //fetch data from DB
            this.data = (from x in ent.DataTableIWant where param == customparam select x).ToList();
            }
       }
    }
