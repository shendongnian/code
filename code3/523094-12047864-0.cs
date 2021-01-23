    class Manager
    {
       ...
       void DoSomething()
       {
          ViewModelA vma = new ViewModelA();
          WindowA wa = new WindowA();
          wa.DataContext = vma;
          wa.ShowDialog();
          ViewModelB vmb = new ViewModelB();
          vmb.SharedData = vma.SharedData;
          WindowB wb = new WindowB();
          wb.DataContext = vmb;
          wb.ShowDialog();
       }
       ...
    }
