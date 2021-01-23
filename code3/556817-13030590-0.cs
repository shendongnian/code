    // Presenter can and should offer common services for the
    // subclasses 
    abstract class Presenter
    {
    
       public void Display()
       {
          OnDisplay();
       }
    
       public void Dismiss()   
       {
          OnDismiss();
       }
       
       
       protected virtual OnDisplay() // hook for subclass
       {   
       }
       
       protected virtual OnDismiss() // hook for subclass
       {   
       }
       
       private NavigationManager _navMgr;
       
       internal NavigationMgr NavigationManager
       {   
          get
          {
             return _navMgr;
          }
          set
          {
             _navMgr = value;
          }
          
       }
       
    }
    
    // NavigationManager is used to transition (or navigate) 
    // between views
    class NavigationManager
    {
    
       Presenter _current;
    
       // use this override if your Presenter are non-persistent (transient)
       public void NavigateTo(Type nextPresenterType, object args)
       {   
          Presenter nextPresenter = Activator.CreateInstance(nextPresenterType);   
          NavigateTo(nextPresenter);   
       }
    
       // use this override if your Presenter are persistent (long-lived)
       public void NavigateTo(Presenter nextPresenter, object args)
       {
          if (_current != null)
          {
             _current.Dismiss()
             _current.NavigationMgr = null;
             _current = null;
          }
    
          if (nextPresenter != null)
          {
             _current = nextPresenter;
             _current.NavigationMgr = this;
             _current.Display(args);
          }         
       }
    
    }
    
    
    class MainMenuPresenter : Presenter
    {
    
       private IMainMenuView _mainMenuView = null;
    
       // OnDisplay is your startup hook
       protected override void OnDisplay()
       {
          // get your view from where ever (injection, etc)
          _mainMenuView = GetView();      
          
          // configure your view
          _mainMenuView.Title = GetMainTitleInCurrentLanguage();
          // etc      
          // etc
          
          // listen for relevent events from the view
          _mainMenuView.NewWorkOrderSelected += new EventHandler(MainMenuView_NewWorkOrderSelected);
          
          // display to the user
          _mainMenuView.Show();
       }
    
       protected override void OnDismiss()
       {
          // cleanup
          _mainMenuView.NewWorkOrderSelected -= new EventHandler(MainMenuView_NewWorkOrderSelected);
          _mainMenuView.Close();
          _mainMenuView = null;
       }
       
       // respond to the various view events
       private void MainMenuView_NewWorkOrderSelected(object src, EventArgs e)
       {
          // example of transitioning to a new view here...
          NavigationMgr.NavigateTo(NewWorkOrderPresenter, null);            
       }
       
    }
    
    
    class NewWorkOrderPresenter : Presenter
    {
    
       protected override void OnDisplay()
       {
          // get the view, configure it, listen for its events, and show it
       }
       
       protected override void OnDismiss()
       {
          // unlisten for events and release the view
       }
       
    }
 
