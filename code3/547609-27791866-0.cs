    ﻿using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;
    using MetroLog;
    using SparkiyClient.UILogic.Services;
    
    namespace SparkiyClient.Services
    {
    	public class NavigationService : INavigationService
    	{
    		private static readonly ILogger Log = LogManagerFactory.DefaultLogManager.GetLogger<NavigationService>();
    		private readonly Dictionary<string, Type> pagesByKey = new Dictionary<string, Type>();
    		private readonly Stack<PageStackEntry> historyStack = new Stack<PageStackEntry>();
    		private PageStackEntry currentPage;
    
    		public string CurrentPageKey { get; private set; }
    
    		public bool CanGoBack => this.historyStack.Any();
    
    		private static Frame GetFrame()
    		{
    			return (Frame)Window.Current.Content;
    		}
    
    		public void GoBack()
    		{
    			if (!this.CanGoBack)
    				return;
    
    			var item = this.historyStack.Pop();
                this.NavigateTo(item.SourcePageType.Name, item.Parameter, false);
    		}
    
    		public void GoHome()
    		{
    			if (!this.CanGoBack)
    				return;
    
    			var item = this.historyStack.Last();
    			this.NavigateTo(item.SourcePageType.Name, item.Parameter, false);
    			this.historyStack.Clear();
    		}
    
    		public void NavigateTo(string pageKey, bool addSelfToStack = true)
    		{
    			this.NavigateTo(pageKey, null, addSelfToStack);
    		}
    
    		public void NavigateTo<T>(bool addToStack = true)
    		{
    			this.NavigateTo<T>(null, addToStack);
    		}
    
    		public void NavigateTo<T>(object parameter, bool addSelfToStack = true)
    		{
    			this.NavigateTo(typeof(T).Name, parameter, addSelfToStack);
    		}
    
    		public void NavigateTo(string pageKey, object parameter, bool addToStack = true)
    		{
    			var lockTaken = false;
    			Dictionary<string, Type> dictionary = null;
    			try
    			{
    				Monitor.Enter(dictionary = this.pagesByKey, ref lockTaken);
    				if (!this.pagesByKey.ContainsKey(pageKey))
    					throw new ArgumentException(string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?", pageKey), "pageKey");
    
    				if (addToStack && this.currentPage != null)
    					this.historyStack.Push(this.currentPage);
    					
    				GetFrame().Navigate(this.pagesByKey[pageKey], parameter);
    
    				this.CurrentPageKey = pageKey;
    				this.currentPage = new PageStackEntry(this.pagesByKey[pageKey], parameter, null);
    
    				Log.Debug(this.historyStack.Reverse().Aggregate("null", (s, entry) => s + " > " + entry.SourcePageType.Name));
    			}
    			finally
    			{
    				if (lockTaken && dictionary != null)
    					Monitor.Exit(dictionary);
    			}
    		}
    
    		public void Configure(string key, Type pageType)
    		{
    			var lockTaken = false;
    			Dictionary<string, Type> dictionary = null;
    			try
    			{
    				Monitor.Enter(dictionary = this.pagesByKey, ref lockTaken);
    				if (this.pagesByKey.ContainsKey(key))
    					this.pagesByKey[key] = pageType;
    				else this.pagesByKey.Add(key, pageType);
    			}
    			finally
    			{
    				if (lockTaken && dictionary != null)
    					Monitor.Exit(dictionary);
    			}
    		}
    	}
    }
