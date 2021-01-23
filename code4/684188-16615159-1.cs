        public class BossValidatorImplementation : IValidation
        {
            public bool IsValid
            {
                get
                {
                    return false; ;
                }
                set
                {
                    throw new InvalidOperationException("I dont allow you to tell me this!");
                }
            }
        }
        public class EasyGoingValidator : IValidation
        {
            public bool IsValid { get; set; }
        }
