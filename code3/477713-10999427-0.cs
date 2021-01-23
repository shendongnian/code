    public class ParticipantService : IParticipantService
    {
        public void Save(Participant participant)
        {
            IValidator<Participant> validator = _validatorFactory.GetValidator<Participant>();
            var results = validator.Validate(participant);
                //if the participant is valid, register the participant with the unit of work
                if (results.IsValid)
                {
                    if (participant.IsNew)
                    {
                        _unitOfWork.RegisterNew<Participant>(participant);
                    }
                    else if (participant.HasChanged)
                    {
                        _unitOfWork.RegisterDirty<Participant>(participant);
                    }
                }
                else
                {
                    _unitOfWork.RollBack();
                    //do some thing here to indicate the errors:generate an exception (or fault) that contains the validation errors. Or return the results
                }
        }
        
    }
