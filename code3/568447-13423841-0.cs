    private DropDownList ctrl;
    protected override void Init(EventArgs e)
    {
          base.Init(e);
          ctrl = new DropDownList
                  {
                       Id = "name of control",
                       DataValueField = "Value", 
                       DataTextField = "Text"
                  };
         
          Controls.Add(ctrl);
    }
    protected override void Load(EventArgs e)
    {
          base.Load(e);
          if(ispostback) return;
          ctrl.DataSource = GetData();
 
          DataBind();
    }
