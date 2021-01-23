    	public class OverridableDataTemplateSelector: DataTemplateSelector
		{
			public override DataTemplate SelectTemplate(object item, DependencyObject container)
			{
				return item as DataTemplate ?? base.SelectTemplate(item, container);
			}
		}
