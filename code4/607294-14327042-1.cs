    	class TemplateSampleViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<TextTemplate> Templates
		{
			get;
			private set;
		}
		private TextTemplate _selectedTemplate;
		public TextTemplate SelectedTemplate
		{
			get{ return _selectedTemplate; }
			set
			{
				if ( _selectedTemplate == value )
					return;
				_selectedTemplate = value;
				if (_selectedTemplate != null)
					Text = _selectedTemplate.TemplateText;
				firePropertyChanged("SelectedTemplate");
			}
		}
		private string _text;
		public string Text
		{
			get { return _text; }
			set
			{
				if ( _text == value )
					return;
				_text = value;
				firePropertyChanged( "Text" );
				var matchingTemplate = Templates.FirstOrDefault( t => t.TemplateText == _text );
				SelectedTemplate = matchingTemplate;
			}
		}
		public TemplateSampleViewModel(IEnumerable<TextTemplate> templates)
		{
			Templates = new ObservableCollection<TextTemplate>(templates);
		}
		private void firePropertyChanged(string propertyName)
		{
			if ( PropertyChanged != null )
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
