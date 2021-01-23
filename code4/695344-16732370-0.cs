    public partial class DataContext1: IDataContext {
    	IQueryable<IFieldCollection> IDataContext.FieldCollections { 
    		get { return FieldCollections.Cast<IFieldCollection>(); }
    	}
    	IQueryable<IField> IDataContext.Fields { 
    		get { return Fields.Cast<IField>(); }
    	}
    }
