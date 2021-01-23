    DesignerVerb _verb;
    _verb = new DesignerVerb("Do something", OnConvertClick);
    var designer = _designerHost.GetDesigner(comp);
    if (!designer.Verbs.Contains(_verb))
      designer.Verbs.Add(_verb);
    void OnConvertClick(object sender, EventArgs e)
    {
       MessageBox.Show("Hello world!");
    }
