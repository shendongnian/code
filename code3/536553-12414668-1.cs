    public partial class RBLTest : UserControl {
        private RadioButton[] _items;
        private int leftSpacing = 100;
        private int topSpacing = 25;
        public RBLTest( ) {
            InitializeComponent( );
        }
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        public RadioButton[] Items {
            get {
                return _items;
            }
            set {
                _items = value;
                int curLeftPos = 0;
                int curTopPos = 0;
                foreach ( RadioButton rb in _items ) {
                    rb.Location = new Point( curLeftPos, curTopPos );
                    rb.Size = new Size( 85, 17 );
                    curLeftPos += leftSpacing;
                    if ( curLeftPos > this.Width ) {
                        curLeftPos = 0;
                        curTopPos += topSpacing;
                    }
                    this.Controls.Add( rb );
                }
            }
        }
    }
