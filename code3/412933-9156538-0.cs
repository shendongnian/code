      public ObsrevableCollection<MyTestItem> MyCollection {get; set;}
      <DatagGrid ItemsSource="{Binding MyCollection}" />
      public void Add()//is called from a not ui thread
      {
          Application.Current.Dispatcher.BeginInvoke((Action)(()=>this.MyCollection.Add(new MyTestItem(){ID=1, Name="Test1"}));
      }
