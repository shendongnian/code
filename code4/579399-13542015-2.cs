    interface ICopyable<T,TU>
    {
    	T Value { get; set; }
    	TU Copy();
    }
    
    class BooleanHolder : ICopyable<Boolean, BooleanHolder> 
    {
    	public bool Value { get; set; }
    	public BooleanHolder Copy() { 
    		return new BooleanHolder(){ Value = Value }; 
    	}
    }
    
    class DecoratingHolder<T,TU> : ICopyable<ICopyable<T,TU>, DecoratingHolder<T,TU>> 
    {
    	public ICopyable<T,TU> Value { get; set; }
    	
    	public DecoratingHolder<T,TU> Copy() {
    		return new DecoratingHolder<T, TU>(){ Value = Value };
    	}
    }
