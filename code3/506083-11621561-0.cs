    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            static System.Drawing.Point _location = new Point();
            static System.Drawing.Size _size;
            static FormWindowState _state;
    
            public Form2()
            {
                InitializeComponent();
    
                this.Load += new EventHandler( Form2_Load );
                this.FormClosing += new FormClosingEventHandler( Form2_FormClosing );
            }
    
            void Form2_Load( object sender, EventArgs e )
            {
                // Restore the Form's position.
                //
                // Handle possibility that our previous screen location is no longer valid for
                // the current display environment (i.e., multiple->single display system).
                //
    
                Point location = _location;
    
                if ( location == new Point( 0, 0 ) || !IsScreenLocationValid( location ) )
                {
                    if ( null != this.Parent )
                        this.StartPosition = FormStartPosition.CenterParent;
                    else
                        this.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    this.Location = location;
    
                    // Ensure that the Form's size is not smaller than its minimum allowed.
                    //
    
                    Size size = _size;
    
                    size.Width = System.Math.Max( size.Width, this.MinimumSize.Width );
                    size.Height = System.Math.Max( size.Height, this.MinimumSize.Height );
    
                    this.Size = size;
                }
    
                // Only restore the Form's window state if it is not minimized.
                // (If we restore it as minimized, the user won't see it).
                //
                if ( _state == FormWindowState.Normal || _state == FormWindowState.Maximized )
                {
                    this.WindowState = _state;
                }
            }
    
            /// <summary>
            /// Determines if the given screen location is valid for the current display system.
            /// </summary>
            /// <param name="location">A Point object describing the location</param>
            /// <returns>True if the location is valid; otherwise, false</returns>
            static bool IsScreenLocationValid( Point location )
            {
                Rectangle screenBounds = System.Windows.Forms.Screen.GetBounds( location );
    
                return screenBounds.Contains( location );
            }
    
            void Form2_FormClosing( object sender, FormClosingEventArgs e )
            {
                _state = this.WindowState;
    
                if ( _state == FormWindowState.Normal )
                {
                    _location = this.Location;
                    _size = this.Size;
                }
                else
                {
                    _location = this.RestoreBounds.Location;
                    _size = this.RestoreBounds.Size;
                }
            }
        }
    }
