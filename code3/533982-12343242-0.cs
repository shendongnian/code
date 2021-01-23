    public class CostumizedTreeView : TreeView {
        Color defaultBackColor;
        public CostumizedTreeView( ) {
            defaultBackColor = BackColor;
        }
        public void Enable( bool Enabled ) {
            this.Enabled = Enabled;
            if ( !Enabled )
                BackColor = Color.LightGray;
            else
                BackColor = defaultBackColor;
        }
    }
