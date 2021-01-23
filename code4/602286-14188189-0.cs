    private void setPoints()
            {
                PointCollection c = new PointCollection();
                //calculating points to collection
    
                Action<PointCollection> updateUI = (state) =>
                    {
                        polyline.Points = state;
                    };
                Application.Current.Dispatcher.Invoke(updateUI, c);
            }
