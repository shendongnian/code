    public class A : ReactiveObject
    {
        public A()
        {
            //Using almost like WhenAny from ReactiveUI
            CanExecuteObservable = this.WhenAny(() => AProp, CanExecute);
            Command = new ReactiveCommand(CanExecuteObservable);
            Command.Subscribe(x => Execute());
        }
        protected CanExecuteObservable CanExecuteObservable { get; private set; }
        public ReactiveCommand Command { get; private set; }
        protected virtual bool CanExecute()
        {
            return AProp > 10;
        }
        private int aProp = 10;
        public int AProp { get { return aProp; } set { this.RaiseAndSetIfChanged(x => x.AProp, value); } }
    }
    public class B : A
    {
        public B()
        {
            //Add one more property dependency for CanExecute
            CanExecuteObservable.AddProperties(() => BProp);
        }
        private int bProp = 10;
        public int BProp { get { return bProp; } set { this.RaiseAndSetIfChanged(x => x.BProp, value); } }
        protected override bool CanExecute()
        {
            return base.CanExecute() && BProp > 100;
        }
    }
