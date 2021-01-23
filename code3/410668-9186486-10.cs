    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    
    namespace Demo
    {
    	[ContentProperty(nameof(Children))]  // Prior to C# 6.0, replace nameof(Children) with "Children"
    	public partial class MultiChildDemo : UserControl
    	{
    		public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
    			nameof(Children),  // Prior to C# 6.0, replace nameof(Children) with "Children"
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
