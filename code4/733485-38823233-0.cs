    using System.Windows;
    using System.Windows.Controls;
    using Autofac;
    namespace ...ClassHandlers
    {
    	public class TabItemTouchClassHandler : IStartable
    	{
    		public void Start()
    		{
    			Register();
    		}
    
    		public void Register()
    		{
    			EventManager.RegisterClassHandler(typeof(TabItem), UIElement.TouchDownEvent, new RoutedEventHandler(OnTabItemTouchDown));
    		}
    
    		//must be static! otherwise memory leaks!
    		private static void OnTabItemTouchDown(object ender, routedEventArgs e)
    		{
    			var tab = sender as TabItem;
    			var control = tab?.Parent as TabControl;
    			if (control != null && !Equals(tab, control.SelectedItem))
    			{
    				control.SelectedItem = tab;
    				e.Handled = true;
    			}
    		}
    	}
    }
