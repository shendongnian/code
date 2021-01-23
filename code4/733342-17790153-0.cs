    // Define interface for table
    public interface ITableA {
    	// ... properties
    }
    // Define interface for context
    public interface IMyContext {
    	IQueryable<ITableA> TableA { get; }
    }
    
    // Extend TableA from DUK1
    public partial class TableA: ITableA {	
    }
    
    // Extend DUK1
    public partial class Datacontext.DAL.DUK1: IMyContext {
    	IQueryable<ITableA> IMyContext.TableA { 
            get { return TableA; }
        }
    }
    
    // Same for DUK3 and TableA FROM DUK3
    
    
    // Finally, your code
    Datacontext.DAL.DUK1 duk1sdi = new     Datacontext.DAL.DUK1(connectionString);
    Datacontext.DAL.DUK3 duk3sdi = new     Datacontext.DAL.DUK3(connectionString);
    
    string fromOne = runQuery(duk1sdi);
    string fromThree = runQuery(duk3sdi);
    
    public static string runQuery(IMyContext duk) { 
        // Note: method accepts interface, not specific context type
    	var query = from result in duk.TableA
    				select result.Total;
    
    	string returnString = query;
    	return returnString;
    }
