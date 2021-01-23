    public class LibraryRegistrator
        {
            public static void Register()
            {
                BuildManager.AddReferencedAssembly(Assembly.LoadFrom(HostingEnvironment.MapPath("~/bin/yourown.dll")));
            }
        }
