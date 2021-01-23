        /// <summary>
        /// The interface for validation strategy (since we are using interface, there is no need for another abstract class)
        /// </summary>
        public interface IValidation
        {
            bool IsValid { get; set; }
        }
        /// <summary>
        /// The decorator (it dont need to be abstract) that has the serializable properties
        /// </summary>
        [Serializable]
        public class ValidatableDecorator : IValidation
        {
            protected IValidation instance;
            public ValidatableDecorator()
            {
                Init();
            }
            public ValidatableDecorator(IValidation instance)
            {
                Init();
            }
            protected virtual void Init() { }
            public void Set(IValidation instance)
            {
                this.instance = instance;
            }
            [XmlIgnore]
            public bool IsValid
            {
                get
                {
                    return instance.IsValid;
                }
                set
                {
                    instance.IsValid = value;
                }
            }
        }
