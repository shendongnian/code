    public abstract class ETLProcess {
    	public final runETL() {
    		IEnumerable rawData = extract();
    		IEnumerable tranformedData = transform(rawData);
    		load(transformedData);
    	}
    	
    	protected abstract IEnumerable extract();
    	protected abstract IEnumerable transform(IEnumerable rawData);
    	protected abstract load(IEnumerable transformedData);
    }
