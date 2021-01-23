    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Collections.Specialized;
    namespace WpfApplication1
    {
        public static class FlowSupport
        {
            private static Dictionary<TextBlock, NotifyCollectionChangedEventHandler> _collChangedHandlers = new Dictionary<TextBlock,NotifyCollectionChangedEventHandler>();
            public static ObservableCollection<string> GetFragments(TextBlock tb) { return (ObservableCollection<string>)tb.GetValue(FragmentsProperty); }
            public static void SetFragments(TextBlock tb, ObservableCollection<string> value) { tb.SetValue(FragmentsProperty, value); }
            public static readonly DependencyProperty FragmentsProperty = DependencyProperty.RegisterAttached("Fragments", typeof(ObservableCollection<string>), typeof(FlowSupport), new PropertyMetadata(new ObservableCollection<string>(), OnFragmentsChanged));
            private static void OnFragmentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var tb = d as TextBlock;
                if (tb != null)
                {
                    CreateCollectionChangedHandler(tb); // create handler, once per textblock
                    tb.Inlines.Clear();
                    var oldInlines = e.OldValue as ObservableCollection<string>;
                    if (oldInlines != null)
                    {
                        oldInlines.CollectionChanged -= _collChangedHandlers[tb];
                    }
                    var inlines = e.NewValue as ObservableCollection<string>;
                    if (inlines != null)
                    {
                        inlines.CollectionChanged += _collChangedHandlers[tb];
                        foreach (string s in inlines)
                            tb.Inlines.Add(s);
                    }
                }
            }
            private static void CreateCollectionChangedHandler(TextBlock tb)
            {
                if (!_collChangedHandlers.ContainsKey(tb))
                {
                    _collChangedHandlers.Add(tb, (s1, e1) =>
                    {
                        if (e1.NewItems != null)
                        {
                            foreach (string text in e1.NewItems)
                                tb.Inlines.Add(text);
                        }
                        if (e1.OldItems != null)
                        {
                            foreach (string text in e1.OldItems)
                            {
                                Inline inline = tb.Inlines.FirstOrDefault(i => ((Run)i).Text == text);
                                if (inline != null)
                                    tb.Inlines.Remove(inline);
                            }
                        }
                    });
                }
            }
        }
    }
