        public class Customer
        {
            public int Id { get; set; }
            public string Surname { get; set; }
            public string Forename { get; set; }
            public decimal Discount { get; set; }
            public string Address { get; set; }
        }
        using FluentValidation;
        public class CustomerValidator : AbstractValidator<Customer>
        {
            public CustomerValidator()
            {
                //RuleFor(customer => customer.Surname).NotNull();
                RuleFor(customer => customer.Surname).NotNull().NotEqual("foo");
            }
        }
        using FluentValidation;
        using Ninject;
        using System;
        public class NInjectValidatorFactory : ValidatorFactoryBase
        {
            private readonly IKernel m_NInjectKernel;
            public NInjectValidatorFactory(IKernel kernel)
            {
                if (kernel == null)
                    throw new ArgumentNullException("NInject kernel injected is null!!");
                m_NInjectKernel = kernel;
            }
            public override IValidator CreateInstance(Type validatorType)
            {
                return m_NInjectKernel.Get(validatorType) as IValidator;
            }
        }
