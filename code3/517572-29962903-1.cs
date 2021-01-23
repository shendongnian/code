    public partial class MyClass: System.Web.UI.Page
    { 
         bool StateFail;
         protected  override object LoadPageStateFromPersistenceMedium() {
            if (StateFail) return null;
            return base.LoadPageStateFromPersistenceMedium();
           }
        protected override void OnInitComplete(EventArgs e) {
            base.OnInitComplete(e);
            if (!IsPostBack) return;
            try
            {
                typeof(System.Web.UI.Page).GetMethod("LoadAllState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(this, new object[0]);
            } catch { StateFail = true; }
            }
    }
}
