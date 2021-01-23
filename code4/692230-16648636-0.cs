    [ExceptionLogger]
    public IList<User> GetUser()
    {
        return _repository.GetUsers();
    }
    public class ExceptionLogger: OnMethodBoundaryAspect
    {
        //getting _logger and ErrorMessages
        public override void OnException(MethodExecutionArgs args)
        {
            ErrorMessages.Add("...");
            _logger.ErrorException("...", ex);
        }
    }
