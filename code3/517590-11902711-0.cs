    public class FormFactory
    {
        public BaseFrom Create(string taxCode)
        {
            switch (taxCode)
            {
                case "RE":
                    return new RealEstateForm();
     
                    // rest of stuff.
            }
        }
    }
