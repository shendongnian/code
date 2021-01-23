    class SelectedProjectChangedEventArgs : EventArgs
    {
    	public Project SelectedProject {get;set;}
    }
    
    class Project
    {
    
    }
    
    interface IReadOnlyModel
    {
    	Project SelectedProject {get;} 
    	event EventHandler<SelectedProjectChangedEventArgs> SelectedProjectChanged;
    }
    
    interface IWritableModel
    {
    	Project SelectedProject {get;set;} 
    	IList<Project> Projects {get;}
    }
    
    class Model : IReadOnlyModel, IWritableModel
    {
    	public Project SelectedProject {get;set;} 
    	public event EventHandler<SelectedProjectChangedEventArgs> SelectedProjectChanged;
    	public IList<Project> Projects {get;set;}
    }
    
    class ProjectsListPresenter
    {
    	readonly IWritableModel _model;
    
    	public ProjectsListPresenter(IWritableModel model)
    	{
    		_model = model;
    	}
    	
    	public void ChangeSelectedProject(Project project)
    	{
    		_model.SelectedProject = project;
    	}
    }
    
    class ProjectDetailsPresenter
    {
    	readonly IReadOnlyModel _model;
    
    	public ProjectDetailsPresenter(IReadOnlyModel model)
    	{
    		_model = model;
    		_model.SelectedProjectChanged += ModelSelectedProjectChanged;
    	}
    	
    	void ModelSelectedProjectChanged(object sender, SelectedProjectChangedEventArgs e)
    	{
    		//update right pane
    	}
    }
        
        
    class WholeFormPresenter
    {
    	public ProjectDetailsPresenter DetailsPresenter {get;private set;}
    	public ProjectsListPresenter ListPresenter {get;private set;}
    
    	public WholeFormPresenter(Model model)
    	{
    		DetailsPresenter = new ProjectDetailsPresenter(model);
    		ListPresenter = new ProjectsListPresenter(model);
    	}
    }
    
    class WholeForm
    {
    	ListBox _projectsListControl;
    	Panel _detailsPanel;
    	public WholeForm()
    	{
    		var presenter = new WholeFormPresenter(new Model());
    		_projectsListControl.Presenter = presenter.ListPresenter;
    		_detailsPanel.Presenter = presenter.DetailsPresenter;
    	}
    }
