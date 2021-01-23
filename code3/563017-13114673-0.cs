    public class Player : Monobehaviour, IColor {
        // ...
        private Color _colorPainted;
        public Color colorPainted {
            get { return _colorPainted; }
            set {
                _colorPainted = value;
                // some other code
            }
         // ...
        }
    }
