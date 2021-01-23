    cb.RegisterType<WalletRepository>()
      .As<IWalletRepository>()
      .SingleInstance();
    cb.Register(c => c.Resolve<IWalletRepository>().CreateAsync(App.WalletPath));
    cb.Register(async c => new ViewModel(await c.Resolve<Task<Wallet>>()))
      .SingleInstance();
    var container = cb.Build();
    var viewModel = await container.Resolve<Task<ViewModel>>();
