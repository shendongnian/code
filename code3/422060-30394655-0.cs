    this.SaveCommand = new MyDelegateCommand<MyViewModel>(this,
        //execute
        () => {
          Console.Write("EXECUTED");
        },
        //can execute
        () => {
          Console.Write("Checking Validity");
           return PropertyX!=null && PropertyY!=null && PropertyY.Length < 5;
        },
        //properties to watch
        (p) => new { p.PropertyX, p.PropertyY }
     );
