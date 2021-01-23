    public class MyModelA
    {
      public string GetSomeData()
      {
        return "Some Data";
      }
    }
    
    public class MyModelB
    {
      public string GetOtherData()
      {
        return "Other Data";
      }
    }
    
    public class MyViewModel
    {
      readonly MyModelA modelA;
      readonly MyModelB modelB;
      
      public MyViewModel(MyModelA modelA, MyModelB modelB)
      {
        this.modelA = modelA;
        this.modelB = modelB;
      }
      
      public string TextBox1Value { get; set; }
      
      public string TextBox2Value { get; set; }
      
      public void Load()
      {
        this.TextBox1Value = modelA.GetSomeData();
        this.TextBox2Value = modelB.GetOtherData();
        // raise INotifyPropertyChanged events here
      }
    }
    
    public class MyView
    {
      readonly MyViewModel vm;
      
      public MyView(MyViewModel vm)
      {
        this.vm = vm;
        // bind to vm here
      }
    }
    
    public class Program
    {
      public void Run()
      {
        var mA = new MyModelA();
        var mB = new MyModelB();
        var vm = new MyViewModel(mA, mB);
        var view = new MyView(vm);
        vm.Load();
        // show view here
      }
    }
