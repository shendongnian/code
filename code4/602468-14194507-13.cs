        private List<KeyValuePair<string,double>> oldVals = new List<KeyValuePair<string,double>>();
        private void ElementInRowOneSizeChanged(object sender, SizeChangedEventArgs e)
        {
            FrameworkElement elem = (FrameworkElement)sender;
            MinHeightRowOne -= oldVals.Find(kvp => kvp.Key == elem.Name).Value;
            elem.Measure(new Size(int.MaxValue, int.MaxValue));
            MinHeightRowOne += elem.DesiredSize.Height;
            oldVals.Remove(oldVals.Find(kvp => kvp.Key == elem.Name));
            oldVals.Add(new KeyValuePair<string, double>(elem.Name, elem.DesiredSize.Height));
        }
