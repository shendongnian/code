        public class ChildWithBossValidation : ValidatableDecorator
        {
            protected ChildWithBossValidation(IValidation instance)
                : this()
            {
                Init();
            }
            public ChildWithBossValidation()
                : base(new BossValidatorImplementation())
            {
                Init();
            }
            protected override void Init()
            {
                Name = "I'm the boss!";
                Sallary = 10000d;
            }
            public string Name { get; set; }
            public double Sallary { get; set; }
        }
        public class ChildWithEasyGoingValidation : ValidatableDecorator
        {
            public ChildWithEasyGoingValidation()
                : base(new EasyGoingValidator())
            {
            }
            protected ChildWithEasyGoingValidation(IValidation instance)
                : this()
            {
            }
            protected override void Init()
            {
                Name = "Do as you please... :)  ";
            }
            public string Name { get; set; }
        }
