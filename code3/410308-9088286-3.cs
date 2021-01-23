    using System;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    namespace SpriteEditor
    {
        public interface IXnaFormContainer
        {
            Control XnaControl { get; }
            XnaControlGame Game { get; set; }
        }
    
        public abstract class XnaControlGame : Microsoft.Xna.Framework.Game
        {
            public Control Parent { get; private set; }
    
            public static void CreateAndShow<T, Q>( )
                where T : Form, IXnaFormContainer, new( )
                where Q : XnaControlGame
            {
                using ( T form = new T( ) )
                {
                    form.Show( );
    
                    using ( Q game = ( Q ) Activator.CreateInstance( typeof( Q ), new object[] { form.XnaControl.Handle, form, form.XnaControl } ) )
                    {
                        form.Game = game;
                        game.Parent = form.XnaControl;
                        game.Run( );
                    }
                }
            }
    
            
            #region Private Vars to Build Embedded Xna Control
    
            IntPtr _XnaDrawingSurface;
            GraphicsDeviceManager graphics;
    
            System.Windows.Forms.Form parentForm;
            System.Windows.Forms.Control controlXna;
    
            System.Windows.Forms.Control gameForm;
    
            #endregion
    
            #region Constructor
    
            public XnaControlGame( IntPtr handle,
                System.Windows.Forms.Form parentForm,
                System.Windows.Forms.Control surfaceControl )
            {
                graphics = new GraphicsDeviceManager( this );
                graphics.GraphicsProfile = GraphicsProfile.Reach;
                Content.RootDirectory = "Content";
    
                this.parentForm = parentForm;
                this.controlXna = surfaceControl;
    
                gameForm = System.Windows.Forms.Control.FromHandle( this.Window.Handle );
                gameForm.VisibleChanged += new EventHandler( gameForm_VisibleChanged );
                controlXna.SizeChanged += new EventHandler( pictureBox_SizeChanged );
    
                // preparing device settings handler. 
                _XnaDrawingSurface = handle;
                Mouse.WindowHandle = handle;
    
                graphics.PreparingDeviceSettings += OnPreparingDeviceSettings;
                graphics.PreferredBackBufferWidth = (controlXna.Width > 0) ? controlXna.Width : 50;
                graphics.PreferredBackBufferHeight = (controlXna.Height > 0) ? controlXna.Height : 50;
    
                parentForm.FormClosed += delegate( object sender, System.Windows.Forms.FormClosedEventArgs e )
                {
                    this.Exit( );
                    Application.Exit( );
                };
            }
    
            #endregion
    
            #region Events
    
            private void OnPreparingDeviceSettings( object sender, PreparingDeviceSettingsEventArgs e )
            {
                e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = _XnaDrawingSurface;
            }
    
            private void gameForm_VisibleChanged( object sender, EventArgs e )
            {
                if ( gameForm.Visible == true )
                    gameForm.Visible = false;
            }
    
            void pictureBox_SizeChanged( object sender, EventArgs e )
            {
                if ( parentForm.WindowState !=
                    System.Windows.Forms.FormWindowState.Minimized )
                {
                    graphics.PreferredBackBufferWidth = controlXna.Width;
                    graphics.PreferredBackBufferHeight = controlXna.Height;
                    graphics.ApplyChanges( );
                    OnSizeChanged( );
                }
            }
    
            protected virtual void OnSizeChanged( ) { }
    
            #endregion         
        }      
    }
