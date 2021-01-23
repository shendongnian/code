    public class OL
    {
        dynamic olService = nnull;
        public OL OL(dynamic a)
        {
              this.olService = parent.service; // <- doesn't compile
              //return this; //remove this !!!!
         }
    }
