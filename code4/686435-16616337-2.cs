    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            // NHibernate configures from the <hibernate-configuration> section of a config file
            var config = new Configuration().Configure();
            Kernel.Register(
                Castle.MicroKernel.Registration.Component.For<ISessionFactory>()
                    .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Castle.MicroKernel.Registration.Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest()
            );
        }
    }
