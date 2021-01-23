    kernel.Bind<NHibernateConfiguration>().To<NHibernateConfiguration>();
    kernel.Bind<NHibernateConfiguration>().To<NHibernateConfiguration>()
          .When(ctx => IsLoggedIn())
          .WithConstructorArgument("loggedUserId", request => user.Id);
    private bool IsLoggedIn()
    {
         // add code to decide if the user is logged in
    }
