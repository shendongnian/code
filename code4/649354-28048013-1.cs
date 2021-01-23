    /// <summary>
    /// Proxy class to easily take actions when a specific property in the "source" changed
    /// </summary>
    /// Last updated: 20.01.2015
    /// <typeparam name="TSource">Type of the source</typeparam>
    /// <typeparam name="TPropType">Type of the property</typeparam>
    public class PropertyChangedProxy<TSource, TPropType> where TSource : INotifyPropertyChanged
    {
    	private readonly Func<TSource, TPropType> _getValueFunc;
    	private readonly TSource _source;
    	private readonly Action<TPropType> _onPropertyChanged;
    	private readonly string _modelPropertyname;
    
    	/// <summary>
    	/// Constructor for a property changed proxy
    	/// </summary>
    	/// <param name="source">The source object to listen for property changes</param>
    	/// <param name="selectorExpression">Expression to the property of the source</param>
    	/// <param name="onPropertyChanged">Action to take when a property changed was fired</param>
    	public PropertyChangedProxy(TSource source, Expression<Func<TSource, TPropType>> selectorExpression, Action<TPropType> onPropertyChanged)
    	{
    		_source = source;
    		_onPropertyChanged = onPropertyChanged;
    		// Property "getter" to get the value
    		_getValueFunc = selectorExpression.Compile();
    		// Name of the property
    		var body = (MemberExpression)selectorExpression.Body;
    		_modelPropertyname = body.Member.Name;
    		// Changed event
    		_source.PropertyChanged += SourcePropertyChanged;
    	}
    
    	private void SourcePropertyChanged(object sender, PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName == _modelPropertyname)
    		{
    			_onPropertyChanged(_getValueFunc(_source));
    		}
    	}
    }
