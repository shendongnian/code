    public interface ITileMapView
    {
        event EventHandler<string> TileMapFileLoaded;
        void OnTileMapLoaded(TileMapModel model);
    }
    
    public class TileMapPresenter
    {
        private readonly ITileMapView view;
    
        public TileMapPresenter(ITileMapView view)
        {
            this.view = view;
            view.TileMapFileLoaded += OnTileMapFileLoaded;
        }
    
        private void OnTileMapFileLoaded(object sender, string filename)
        {
            // Parse data from file
            // Populate model
    
            // Tell view
            view.OnTileMapLoaded(model); //Implement the 'AdjustHScrollBar' logic in the view
        }
    }
