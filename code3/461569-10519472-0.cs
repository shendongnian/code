    public class TfsRepositoryProvider : Provider<TfsRepository>
        {
            private const string SesTfsRepository = "SES_TFS_REPOSITORY";
    
            protected override TfsRepository CreateInstance(IContext context)
            {
                // Retrieve services from kernel
                HttpContextBase httpContext = context.Kernel.Get<HttpContextBase>();
                
                if (httpContext == null || httpContext.Session == null)
                {
                    throw new Exception("No bind service found in Kernel for HttpContextBase");
                }
    
                return (httpContext.Session[SesTfsRepository] ?? (
                        httpContext.Session[SesTfsRepository] = new TfsRepository(context.Kernel.Get<IWorkItemStoreWrapper>()))
                    ) as TfsRepository;
            }
        }
