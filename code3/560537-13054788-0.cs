	public class MyTemplateSelector : DataTemplateSelector
	{
		private static DataTemplate _eventsViewModel;
		private static DataTemplate EventsViewModel
		{
			get
			{
				if (_eventsViewModel== null)
					_eventsViewModel= Application.Current.FindResource("EventsViewModel") as DataTemplate;
				return _eventsViewModel;
			}
		}
		private static DataTemplate _plainViewModel;
		private static DataTemplate PlainViewModel
		{
			get
			{
				if (_plainViewModel== null)
					_plainViewModel= Application.Current.FindResource("PlainViewModel") as DataTemplate;
				return _plainViewModel;
			}
		}
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if(item is EventsViewModel) return EventsViewModel;
			else if(item is PlainViewModel) return PlainViewModel;
		}
    }
