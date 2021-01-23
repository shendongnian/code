        protected override void FillTargetFactories(MvvmCross.Binding.Interfaces.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(
                        new MvxCustomBindingFactory<Button>(
                           "IsFavorite", 
                           (button) => new FavoritesButtonBinding(button)));
        }
