    public partial class Form1 : Form {
        Point cursorPosition;
        Direction cursorDirection, previousCursorPosition;
        public event EventHandler<MouseDirectionEventArgs> DirectionChanged;
        public Form1( ) {
            InitializeComponent( );
            cursorPosition = PointToClient( Cursor.Position );
            DirectionChanged += new EventHandler<MouseDirectionEventArgs>( Form1_DirectionChanged );
        }
        void Form1_DirectionChanged( object sender, MouseDirectionEventArgs e ) {
            MessageBox.Show( e.MouseDirection.ToString( ) );
        }
        protected override void OnMouseMove( MouseEventArgs e ) {
            if ( e.X > cursorPosition.X && e.Y > cursorPosition.Y )
                cursorDirection = Direction.RightDown;
            else if ( e.X > cursorPosition.X && e.Y < cursorPosition.Y )
                cursorDirection = Direction.RightUp;
            else if ( e.X < cursorPosition.X && e.Y > cursorPosition.Y )
                cursorDirection = Direction.LeftDown;
            else if ( e.X < cursorPosition.X && e.Y < cursorPosition.Y )
                cursorDirection = Direction.LeftUp;
            OnDirectionChanged(new MouseDirectionEventArgs( cursorDirection ) );
 
            previousCursorPosition = new Point(cursorPosition.X, cursorPosition.Y);
            cursorPosition = e.Location;
            base.OnMouseMove( e );
        }
        protected virtual void OnDirectionChanged(MouseDirectionEventArgs e){
            if ( DirectionChanged != null )
                DirectionChanged( this, e );
        }
    }
    enum Direction {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }
    class MouseDirectionEventArgs : EventArgs {
        public readonly Direction MouseDirection {
            get;
            set;
        }
        public MouseDirectionEventArgs( Direction direction ) {
            MouseDirection = direction;
        }
    }
