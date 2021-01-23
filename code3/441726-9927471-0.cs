    class Tile
    {
        public event EventHandler Clicked = delegate{};
    }
    
    class Board
    {
        private void OnTileClick(object source, EventArgs e)
        {
            var tile = (Tile)source;
            //doSome
    
            var args = new CustomEventArgs();
            CustomEvent(this, args);
        }
    
        public event EventHandler<CustomEventArgs> SomeEvent = delegate{};
    }
    
    public class SomeCustomEventArgs : EventArgs
    {
    }
