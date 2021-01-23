    public class ModernContentLoader : DefaultContentLoader
    {
        protected override object LoadContent(Uri uri)
        {
            var content = base.LoadContent(uri);
            
            if (content == null)
                return null;
            // Locate the right viewmodel for this view
            var vm = Caliburn.Micro.ViewModelLocator.LocateForView(content);
            
            if (vm == null)
                return content;
            // Bind it up with CM magic
            if (content is DependencyObject)
            {
                Caliburn.Micro.ViewModelBinder.Bind(vm, content as DependencyObject, null);
            }
            return content;
        }
    }
