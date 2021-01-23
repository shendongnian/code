    public partial class SkeletonXnaGame : XnaControlGame
    {
        public SkeletonXnaGame( IntPtr ptr, Form form, Control control ) 
            : base( ptr, form, control ) { }
        //--------------------------------------------------------------------------
        protected override void Update( GameTime gameTime )        
        {
            float Seconds = ( float ) gameTime.ElapsedGameTime.TotalSeconds;
          
            HandleMouse( );
            if ( TryHandleCamera( ) ) return;
            if ( MouseIsInsideViewport) HandleLeftClick( Seconds );
            if ( SkeletonManager.SelectedBone != null ) UpdateSelectedBone( Seconds );
            if ( SkeletonManager.SelectedShape != null ) UpdateSelectedShape( Seconds );
            if ( SkeletonManager.CurrentSequence != null ) SkeletonManager.CurrentSequence.Update( Seconds );
            base.Update( gameTime );
        }
        ....
    }
