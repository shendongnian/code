  		private ObservableCollection<FrameworkElement> elements;
		public ObservableCollection<FrameworkElement> Elements
		{
			get { return elements; }
			set
			{
				if(elements != null)
					elements.CollectionChanged -= onElementsChanged;
				elements = value;
				if(elements != null)
					elements.CollectionChanged += onElementsChanged;
				
				NotifyPropertyChanged("Elements");
				NotifyPropertyChanged("ElementsAsStrings");
			}
		}
		
		public IEnumerable<string> ElementsAsStrings
		{
			get
			{
				foreach(var element in Elements)
				{
					if(element is TextBox)
						yield return (element as TextBox).Text;
					// More cases here
				}
			}
		}
		
		private void onElementsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyPropertyChanged("ElementsAsStrings");
		}
