    public class ModelView 
    {
        private IEnumerable<Data> _data = ....
        public string Filtrer {get;set;}
       
        public IEnumerable<Data> GetData() {
    
              return FilteredData();
        }
    
        private IEnumerable<Data> FilteredData()
       {
          if(string.IsNullOrEmpty(Filter))
             return _data;
          
          return   _data.Where(x=>x...Filter); //SOME CONDITON EXECUTION
       }
    }
