    public partial class DataContext1: IDataContext {
    	IQueryable<IFieldCollection> IDataContext.FieldCollections { 
    		get { return FieldCollections; }
    	}
    	IQueryable<IField> IDataContext.Fields { 
    		get { return Fields; }
    	}
    }
