    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Infragistics.Windows.DataPresenter;
    using Infragistics.Windows.Editors;
    
    namespace XamDataGridApp
    {
        class XamTextEditorConverter : IMultiValueConverter
        {
            private static readonly IList<Brush> colors = new Brush[] { Brushes.Red, Brushes.Green, Brushes.Blue };
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var displayText = (string)values[0] ?? string.Empty;
    
                // Context that can be used for custom coloring.
                var editor = (XamTextEditor)values[1];
                var dataItemPresenter = editor.Host as DataItemPresenter;
    
                // Context that can be used for custom coloring.
                var dataValue = editor.Value;
                var dataItem = dataItemPresenter != null ? dataItemPresenter.Record.DataItem : null;
    
                var textBlock = new TextBlock()
                {
                    TextWrapping = editor.TextWrapping,
                    TextAlignment = editor.TextAlignment
                };
    
                for (int i = 0; i < displayText.Length; ++i)
                    textBlock.Inlines.Add(new Run(displayText[i].ToString()) { Foreground = colors[i % colors.Count] });
    
                return textBlock;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
