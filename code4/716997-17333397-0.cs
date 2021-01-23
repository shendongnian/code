    public sealed class App : IFrameworkView
    {
    	public virtual void Initialize(CoreApplicationView AppView)
    	{
    		AppView.Activated += new TypedEventHandler <CoreApplicationView, IActivatedEventArgs>(OnActivated);
    	}
    
    	public virtual void SetWindow(CoreWindow Window)
    	{
    	}
    	public virtual void Load(string EntryPoint)
    	{
    	}
    	public virtual void Run()
    	{
    	}
    	public virtual void Uninitialize()
    	{
    	}
    
    	public void OnActivated(CoreApplicationView CoreAppView, IActivatedEventArgs Args)
    	{
    		CoreWindow Window = CoreWindow.GetForCurrentThread();
    		Window.Activate();
    	}
    }
