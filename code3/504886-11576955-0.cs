    public interface IReload{
        public void reload();
    }
    public partial class Control2: System.Web.UI.UserControl, IReload
    {
    }
    public partial class Control1: System.Web.UI.UserControl
    {
        IReload _r;
        public IReload setReload
        {
          set { _r = value; }
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            BrowseProject b = new BrowseProject();
            b.load();
            if(_r != null){
                _r.reload();
            }
    }
    public partial class MainControl : System.Web.UI.UserControl
    {
            public void load()
        {
            Control codeEditor = Page.LoadControl("Control2.ascx");
            PlaceHolder4.Controls.Clear();
            PlaceHolder4.ID = "PlaceHolder4";
            PlaceHolder4.Controls.Add(codeEditor);
            c.setReload(codeEditor);
        }
