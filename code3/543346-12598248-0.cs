    interface IDomainCommand { }
    class CancelCommand : IDomainCommand { }
    class AcceptCommand : IDomainCommand { }
            Action<CancelCommand> a1 = c => { };
            Action<IDomainCommand> a2 = a1;
            var acceptCommand = new AcceptCommand();
            a2(acceptCommand); // what???
