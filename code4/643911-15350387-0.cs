    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    
    namespace WpfApplication
    {
        public static class Bindable
        {
            public static readonly DependencyProperty InlinesProperty = DependencyProperty.RegisterAttached("Inlines", typeof(IEnumerable<Inline>), typeof(Bindable), new PropertyMetadata(OnInlinesChanged));
    
            private static void OnInlinesChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
            {
                var textBlock = source as TextBlock;
    
                if (textBlock != null)
                {
                    textBlock.Inlines.Clear();
                    var inlines = e.NewValue as IEnumerable<Inline>;
                    if (inlines != null)
                        textBlock.Inlines.AddRange(inlines);
                }
            }
    
            [AttachedPropertyBrowsableForType(typeof(TextBlock))]
            public static IEnumerable<Inline> GetInlines(this TextBlock textBlock)
            {
                return (IEnumerable<Inline>)textBlock.GetValue(InlinesProperty);
            }
    
            public static void SetInlines(this TextBlock textBlock, IEnumerable<Inline> inlines)
            {
                textBlock.SetValue(InlinesProperty, inlines);
            }
        }
    }
