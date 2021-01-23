    public partial class FormView
    {
        private System.ComponentModel.IContainer components = null;
        private SplitContainer MainContainer;
        private TreeView Items;
        private MenuStrip MainMenu;
        private ToolStripMenuItem File;
        private ToolStripMenuItem AddFeed;
        private ToolStripSeparator Separator;
        private ToolStripMenuItem Quit;
        private ContextMenuStrip ContextMenu;
        private ToolStripMenuItem RemoveItem;
        private WebBrowser Message;
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.Items = new System.Windows.Forms.TreeView();
            this.Message = new System.Windows.Forms.WebBrowser();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFeed = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator = new System.Windows.Forms.ToolStripSeparator();
            this.Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            /*  there goes properties initializing, like setting names, sizes etc  */
        }
        // Added just in case
                
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
