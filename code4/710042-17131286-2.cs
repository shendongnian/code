        class HighlightPartOfTextConverter : IValueConverter {
        public object Convert(object value/*this is TextBlock*/, Type type, object parameter/*this is 'Emi'*/, CultureInfo ci){
            var textBlock = value as TextBlock; 
            string str = textBlock.Tag as string;
            string searchThis = parameter as string;
            int index = str.IndexOf(searchThis);
            if(index >= 0){
                string before = str.Substring(0, index);
                string after = str.Substring(index + searchThis.Length);
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add(new Run(){Text=before});
                textBlock.Inlines.Add(new Run(){Text=searchThis, FontWeight = FontWeights.Bold});
                textBlock.Inlines.Add(new Run(){Text=after});
            }
            return "";
           }
          public object ConvertBack(...) {...}
        }
