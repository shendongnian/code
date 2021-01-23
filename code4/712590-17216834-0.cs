    public class MyColorResource
    {
        /// <summary>
        /// The resource name - as it can be referenced by within the app
        /// </summary>
        private const string ResourceName = "MyColorResource";
        /// <summary>
        /// Initializes a new instance of the <see cref="MyColorResource"/> class.
        /// </summary>
        public MyColorResource()
        {
            try
            {
                // This doesn't work in the designer - so don't even try
                if (DesignerProperties.IsInDesignTool)
                {
                    return;
                }
                // Make sure we don't try and add the resource more than once - would happen if referenced on multiple pages or in app and page(s)
                if (!Application.Current.Resources.Contains(ResourceName))
                {
                    if (Visibility.Visible == (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"])
                    {
                        Application.Current.Resources.Add(ResourceName, new SolidColorBrush(Colors.Red));
                    }
                    else
                    {
                        Application.Current.Resources.Add(ResourceName, new SolidColorBrush(Colors.Gray));
                    }
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong - ask for your money back");
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
    }
