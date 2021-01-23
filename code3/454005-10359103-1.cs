        // Custom Model Binders
        System.Web.Mvc.ModelBinders.Binders.Add(
            typeof(MyCompany.Thing)
            , new MyMvcApplication.ModelBinders.ThingModelBinder(
                WindsorContainer.Resolve<IThingFactory>()
                )
            );
