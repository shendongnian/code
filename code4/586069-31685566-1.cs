    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
            SetPermissions();
            FillView(1);
        }
    }
    protected void gvPresupuestos_PreRender(object sender, EventArgs e)
    {
        // Habilita bootstrap
        gvPresupuestos.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void gvPresupuestos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // This is never fired by the LinkButton in the ItemTemplate
        // But the ButtonField actually fires it.
        if (e.CommandName.Equals("Deshabilitar"))
        {
            // This is how I've been doing it in the whole project but thanks to this 
            // shit I can't use the CommandArgument of the LinkButton in the ItemTemplate
            // Guid idPresupuesto = new Guid(e.CommandArgument.ToString());
            
            // I don't know what I'm supposed to do now. 
            // ¿Why this only happens in this page?, ¿WTF?
            Guid idPresupuesto = gvPresupuestos.GetTheIdFromDataKeysWithFuckingMagic();
            var cliente = ClientFactory.CreateServiceClient();
            using (cliente as IDisposable)
            {
                cliente.DeshabilitarPresupuesto(idPresupuesto);
            }
        }
        FillView(1);
    }
    protected void gvPresupuestos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPresupuestos.PageIndex = e.NewPageIndex;
        FillView(e.NewPageIndex + 1);
    }
    #region helper methods
    private void InitializeControls()
    {
        // Not required yet
    }
    private void FillView(int desiredPage)
    {
        var cliente = ClientFactory.CreateAuthServiceClient();
        using (cliente as IDisposable)
        {
            var resultado = cliente.ObtenerTiposDePresupuesto();
            gvPresupuestos.DataSource = resultado;
            gvPresupuestos.DataBind();
        }
    }
    private void SetPermissions()
    {
        // not required yet
    }
    #endregion
