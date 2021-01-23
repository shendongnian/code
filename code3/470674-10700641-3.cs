        protected override void FillTargetFactories(MvvmCross.Binding.Interfaces.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(new MvxCustomBindingFactory<TextView>("TextColor", (textView) => new MyCustomBinding(textView)));
        }
