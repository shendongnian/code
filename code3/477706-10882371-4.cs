     public class MyCommandHandler :  CommandHandler<MyCommand>
    {
      public override CommandValidation Execute(MyCommand cmd)
            {
                Contract.Requires<ArgumentNullException>(cmd != null);
    
               var existingAR= Repository.GetById<MyAggregate>(cmd.Id);
    
                if (existingIntervento.IsNull())
                    throw new HandlerForDomainEventNotFoundException();
    
                existingIntervento.DoStuff(cmd.Id
                                    , cmd.Date
                                    ...
                                    );
    
    
                Repository.Save(existingIntervento, cmd.GetCommitId());
    
                return existingIntervento.CommandValidationMessages;
            }
