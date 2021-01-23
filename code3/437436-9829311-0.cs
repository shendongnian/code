    protected override void
    OnPreLoad(EventArgs e) {
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        MyData.BusinessDataStorage.GetData().ForEach(item =>
        {
            ScriptManager.RegisterArrayDeclaration(Page, "pageData", serializer.Serialize(item));
        });
        base.OnPreLoad(e); }
