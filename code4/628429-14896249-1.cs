    if(Control.Dispatcher.CheckAccess())
    {
        //The control can be accessed without using the dispatcher.
        Control.DoSomething();
    }
    else{
         //The dispatcher of the control needs to be informed
         MyDelegate md = new MyDelegate( delegate() { Control.DoSomething(); });
         Control.Dispatcher.Invoke(md, null);
    }
