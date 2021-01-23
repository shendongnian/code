     using System.Collections.ObjectModel;
     public MyClass
     {
          public ObservableCollection<MyObject> myList { get; set; }
          public MyClass()
          {
               this.DataContext = this;
               myList = new ObservableCollection<MyObject>();
               myList.Add(new MyObject() { MyProperty = "foo", MyBool = false };
               myList.Add(new MyObject() { MyProperty = "bar", MyBool = true };
          }
     }
     public MyObject
     {
          public string MyProperty { get; set; }
          // I believe will result in checkbox in the grid
          public bool MyBool { get; set; }
          //...as many properties as you want
     }
