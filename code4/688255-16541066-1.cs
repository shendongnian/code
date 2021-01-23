    public class BusinessObjectBuilder
    {
        public BusinessObjectBuilder(IBusinessObjectValidator validator){
            this.validator = validator;
        }
        IBusinessObjectValidator validator;
    
        public BusinessObject Build(SetOfData<SomeType> setofdata)
        {
            // an example of some validation
            if (validator.IsValid(setofdata))
                return new BusinessObject(setofdata);
            }
            else
            {
                throw new //exception
            }
        }
    }
