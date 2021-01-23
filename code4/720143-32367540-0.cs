            kernel.Bind<ICustomUser>()
                .To<User>()
                .When(ctx => HttpContext.Current.User.Identity.IsAuthenticated)
                .InRequestScope();
            kernel.Bind<ICustomUser>()
                .To<Guest>()
                .When(ctx => !HttpContext.Current.User.Identity.IsAuthenticated)
                .InRequestScope();
