    class MyTest<T> where T : IStepViewModel
        {
            void Test()
            {
                IStepModelBuilder<T> cannotImplicitlyCast = new SpecificStepViewModelBuilder();
            }
        }
