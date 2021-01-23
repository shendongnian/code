    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;
    
    namespace WpfApplication
    {
        public class MyViewModel
        {
            // This is against MVVM principle - to contain views (Inlines) in view model, but I don't want to complicate by creating ViewModel class for each Inline derived class.
            public IEnumerable<Inline> Inlines { get; private set; }
    
            public MyViewModel()
            {
                this.Inlines = new Inline[]
                {
                    new Run("meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr  lange run 1"),
                    new Run("meine run2") { Foreground = Brushes.Green, Typography = { Variants = FontVariants.Superscript } },
                    new Run("meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr  lange run"),
                    new Run("meine run3") { Foreground = Brushes.LimeGreen, Background = Brushes.Yellow },
                    new Run("meine sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr sehr  lange run")
                };
            }
        }
    }
