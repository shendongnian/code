    public class A
    {
        public ReactiveCommand SomeCommand { get; protected set; }
        public A()
        {
            SomeCommand = new ReactiveCommand(this.WhenAny(x => x.SomeProp, ...));
        }
    }
    public class B : A
    {
        public A()
        {
            var newWhenAny = this.WhenAny(x => x.SomeOtherProp, ...);
            var canExecute = SomeCommand == null ?
                newWhenAny :
                SomeCommand.CanExecuteObservable.CombineLatest(newWhenAny,(oldCommand, whenAny) => oldCommand && whenAny);
            SomeCommand = new ReactiveCommand(canExecute);
        }
    }
