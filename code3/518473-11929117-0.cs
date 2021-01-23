    private void LoadSeries(DataTable table)
    {
        ...
        {
            var series = new Series(id, name, season, episode);
            series.PropertyChanged += { RaisePropertyChanged("SeriesCollection"); }
            SeriesCollection.Add(series);
        }
    }       
   
