    public class MyView : Window
	{
		public MyView()
		{
			...
			Load += (s,e)=> 
			{
				if (this.DataContext is INavigatable)
				{
					((INavigatable)(this.DataContext)).Navigate += (s1,e1) => webView.Navigate(e1.Target);
				}
			}
		
		}
	}
