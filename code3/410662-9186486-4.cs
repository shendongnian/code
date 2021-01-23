    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    
    namespace Demo
    {
    	[ContentProperty("Children")]
    	public partial class MultiChildDemo : UserControl
    	{
    		public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
    			"Children",
    			typeof(UIElementCollection),
    			typeof(MultiChildDemo),
    			new PropertyMetadata());
    
    		public UIElementCollection Children
    		{
    			get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
    			private set { SetValue(ChildrenProperty, value); }
    		}
    
    		public MultiChildDemo()
    		{
    			InitializeComponent();
    			Children = PART_Host.Children;
    		}
    	}
    }
