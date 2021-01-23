    kernel.Bind<IHtmlPageRepository>()
          .To<HtmlPageRepository>()
          .WhenInjectedInto<HtmlPageModel>();
    kernel.Bind<IHtmlPageRepository>()
          .To<NullRepository>()
          .WhenInjectedInto<VideoPageViewModel>();
