    using System;
    using System.Collections.Generic;
    using MvcSiteMapProvider.Web.Mvc;
    using MvcSiteMapProvider.Caching;
    using System.Web;
    
    public class SessionStateCacheProvider<T>
    	: ICacheProvider<T>
    {
    	public SessionStateCacheProvider(
    		IMvcContextFactory mvcContextFactory
    		)
    	{
    		if (mvcContextFactory == null)
    			throw new ArgumentNullException("mvcContextFactory");
    		this.mvcContextFactory = mvcContextFactory;
    	}
    	private readonly IMvcContextFactory mvcContextFactory;
    
    	protected HttpContextBase Context
    	{
    		get
    		{
    			return this.mvcContextFactory.CreateHttpContext();
    		}
    	}
    
    	#region ICacheProvider<ISiteMap> Members
    
    	public bool Contains(string key)
    	{
    		return (Context.Session[key] != null);
    	}
    
    	public Caching.LazyLock Get(string key)
    	{
    		return (LazyLock)Context.Session[key];
    	}
    
    	public bool TryGetValue(string key, out Caching.LazyLock value)
    	{
    		value = this.Get(key);
    		if (value != null)
    		{
    			return true;
    		}
    		return false;
    	}
    
    	public void Add(string key, LazyLock item, ICacheDetails cacheDetails)
    	{
    		// NOTE: cacheDetails is normally used to set the timeout - you might
    		// need to roll your own method for doing that.
    		Context.Session[key] = item;
    	}
    
    	public void Remove(string key)
    	{
    		Context.Session.Remove(key);
    	}
    
    	public event EventHandler<MicroCacheItemRemovedEventArgs<T>> ItemRemoved;
    
    	#endregion
    
    	// NOTE: Normally this is called by a callback from the cache when an item exprires.
    	// It is required to ensure there is no memory leak because a sitemap has circular references
    	// that need to be broken explicitly. You need to work out how to call this when the user's session
    	// expires.
    	protected virtual void OnCacheItemRemoved(MicroCacheItemRemovedEventArgs<T> e)
    	{
    		if (this.ItemRemoved != null)
    		{
    			ItemRemoved(this, e);
    		}
    	}
    
    }
