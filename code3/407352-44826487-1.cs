        using FluentValidation;
        using Ninject;
        using System;
        using System.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                // Set up the DI Container.
                var kernel = new StandardKernel();
                kernel.Bind<IValidator<Customer>>().To<CustomerValidator>().InSingletonScope();
                var nInjectvalidationFactory = kernel.Get<NInjectValidatorFactory>();
                var customer = kernel.Get<Customer>();
                var customerValidator = nInjectvalidationFactory.GetValidator<Customer>();
                var results = customerValidator.Validate(customer);
                if (!results.IsValid)
                    results.Errors.ToList().ForEach(e =>
                    {
                        Console.WriteLine(e.ErrorMessage);
                        Console.WriteLine(e.ErrorCode);
                        Console.WriteLine(e.PropertyName);
                        Console.WriteLine(e.ResourceName);
                        Console.WriteLine(e.Severity);
                    }
                    );
                Console.ReadLine();
            }
        }
