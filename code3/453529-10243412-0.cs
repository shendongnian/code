    public SwitchingValueProviderProxy: IValueProvider
    {
        private readonly ValueProvider1 provider1;
        private readonly ValueProvider2 provider2;
        public SwitchingValueProviderProxy(
            ValueProvider1 provider1,
            ValueProvider2 provider2)
        {
            this.provider1 = provider1;
            this.provider2 = provider2;
        }
        void IValueProvider.Execute(option option)
        {
            this.GetProvider(option).Execute(option);
        }
        private IValueProvider GetProvider(string option)
        {
            // custom instance logic here
            if (option.EndsWith("1"))
                return this.provider1;
            if (option.EndsWith("2"))
                return this.provider2;
            throw InvalidOperationException();
        }
    }
