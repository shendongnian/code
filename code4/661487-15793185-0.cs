    public class MyTabItem : TabItem
    {
       public MyTabItem()
       {
          Loaded += MyLoadedExtras;
       }
    
       private void MyLoadedExtras( object sender, EventArgs e )
       {
          object basis = TryFindResource("XKeyValueFromYourTabItemStyle");
          if (basis != null)
             Style = (Style)basis;
    
          // disconnect from loaded event after our one time in
          Loaded -= MyLoadedExtras;
       }
    }
	
