    void Main()
    {
    	List<dynamic> flexibleList = new List<dynamic>();
    	dynamic aa = new FlexibleTable();
    	aa.ColumnA = "testA";
    	aa.ColumnB="testB";
    	flexibleList.Add(aa);
    	aa = new FlexibleTable();
    	aa.ColumnA = "testA1";
    	aa.ColumnB="testB1";
    	flexibleList.Add(aa);
    	foreach(dynamic item in flexibleList){
    	  foreach(var columnName in item.VisibleColumns){
    	  
    	     new object[]{item[columnName]}.Dump();
    		
    	  }
    	}
    }
    
    // Define other methods and classes here
    public class FlexibleTable: DynamicObject{
     private Dictionary<string,object> Columns{get; set;}
     public FlexibleTable(){
       this.Columns = new Dictionary<string,object>();
     }
      public  override bool TryGetMember(GetMemberBinder binder, out object result){
       if(Columns.ContainsKey(binder.Name)){
         	result = Columns[binder.Name];
    		return true;
       }else{
       		result = null;
       		return false;
    		}
      }
      public  override bool TrySetMember(SetMemberBinder binder, object value){
        Columns[binder.Name] = value;
    	return true;
      }
      
      public override bool TryGetIndex(
            GetIndexBinder binder, object[] indexes, out object result)
        {
    
            string index = (string)indexes[0];
            return Columns.TryGetValue(index , out result);
        }
    
      
      public IEnumerable<string> VisibleColumns{
         get{	return Columns.Select(x=>x.Key);}
      }
      
    }
