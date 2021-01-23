    public class CreateNewUserCommand
    {
        public string UserName { get; set; }
    }
    internal class CreateNewUserCommandHandler
        : ICommandHandler<CreateNewUserCommand>
    {
        private readonly IUnitOfWork uow;
        public CreateNewUserCommandHandler(
            IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Handle(CreateNewUserCommand command)
        {
            // TODO Validation
            var user = new User { Name = command.Name };
            this.uow.Users.InsertOnSubmit(user);
        }
    }
