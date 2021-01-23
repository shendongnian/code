    //in your usercontrol:
        public static readonly DependencyProperty CurrentItemProperty = 
         DependencyProperty.Register("CurrentItem", typeof(MyListBoxItemObject), 
        typeof(MyUserControl), new PropertyMetadata(default(MyListBoxItemObject)));
        public LiveTextBox CurrentItem
        {
            get { return (MyListBoxItemObject)GetValue(CurrentItemProperty ); }
            set { SetValue(CurrentItemProperty , value); }
        }
    //in your window xaml   
 
        <MyUserControl CurrentItem={Binding MyCurrentItem} ... />
    
