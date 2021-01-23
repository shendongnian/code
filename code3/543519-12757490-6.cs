    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    public partial class ModelBinder
    {
    	/// <summary>
    	/// Binds the values of an Dictionary to a POCO model
    	/// </summary>
    	public virtual T BindModel<T>(IDictionary<string, object> dictionary)
    	{
    		DictionaryValueProvider<object> _dictionaryValueProvider = new DictionaryValueProvider<object>(dictionary, null);
    		return BindModel<T>(_dictionaryValueProvider);
    	}
    
    	/// <summary>
    	/// Binds the values of an IValueProvider collection to a POCO model
    	/// </summary>
    	public virtual T BindModel<T>(IValueProvider dictionary)
    	{
    		Type _modelType = typeof(T);
    		var _modelConstructor = _modelType.GetConstructor(new Type[] { });
    		object[] _params = new object[] { };
    		string _modelName = _modelType.Name;
    		ModelMetadata _modelMetaData = ModelMetadataProviders.Current.GetMetadataForType(() => _modelConstructor.Invoke(_params), _modelType);
    		var _bindingContext = new ModelBindingContext() { ModelName = _modelName, ValueProvider = dictionary, ModelMetadata = _modelMetaData };
    		DefaultModelBinder _binder = new DefaultModelBinder();
    		ControllerContext _controllerContext = new ControllerContext();
    		T _object = (T)_binder.BindModel(_controllerContext, _bindingContext);
    
    		return _object;
    	}
    }
