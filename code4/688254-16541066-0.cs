    public class BusinessObject
    {
        const Threshold = 10;
    
        public BusinessObject(SetOfData<SomeType> setofdata)
        {
            // an example of some validation
            if (setofdata.count > Threshold)
            {
                throw new InvalidOperationException("Set data must be above treshold");
            }
        }
    }
