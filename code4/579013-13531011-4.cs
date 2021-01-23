    class StudentViewModel : INotifyPropertyChanged
    {
    	...
    	
    	public StudentViewModel(Student model)
    	{
    		this._model = model;
    		
    		this._model.PropertyChanged += (sender, e) =>
    		{
    			if(e.PropertyName == "StudentLastName")
    			{
    				this.OnPropertyChanged("StudentLastName");
    			}
    		};
    	}
    }
