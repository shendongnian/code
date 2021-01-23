    // Player.cs
    
    private Color _colorPainted;
    
    public class Player : Monobehaviour, IColor {
        // ...
        public Color colorPainted {
            get { return _colorPainted; }
            set {
                _colorPainted = value;
                // some other code
            }
         // ...
        }
    }
