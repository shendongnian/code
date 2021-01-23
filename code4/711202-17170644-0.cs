    public class ItemsList : ListView {
          public static readonly DependencyProperty ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(ImageSource), typeof(ItemsList));
          public ImageSource ItemIcon {
             get { return (ImageSource)GetValue(ItemIconProperty); }
             set { SetValue(ItemIconProperty, value); }
          }  
    	  
    	  public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(ItemsList));
          public ControlTemplate DoubleClickCommand {
             get { return (ControlTemplate)GetValue(DoubleClickCommandProperty); }
             set { SetValue(DoubleClickCommandProperty, value); }
          }
    }
