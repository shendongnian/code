     public class ThemeResourceProvider : IThemeResourceProvider
     {
     public Stream LoadBigLogo()
     {
         Assembly ambly = Assembly.GetExecutingAssembly();
         return ambly.GetManifestResourceStream("namespace.image.jpg");
      }
      (...)
      }
