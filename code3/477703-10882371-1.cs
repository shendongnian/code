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
     public void DoStuff(Guid id, DateTime dateX,DateTime start, DateTime end, ...)
            {
                var is_date_valid = new Is_dateX_valid(DateX);
                var has_start_date_greater_than_end_date = new Has_start_date_greater_than_end_date(start, end);
            ISpecification<MyAggregate> specs = is_date_valid .And(has_start_date_greater_than_end_date );
            if (specs.IsSatisfiedBy(this))
            {
                var evt = new AgregateStuffed()
                {
                    Id = id
                    , DateX = dateX
                   
                    , End = end        
                    , Start = start
                    , ...
                };
                RaiseEvent(evt);
            }
        }
 
