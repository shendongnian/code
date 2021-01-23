    public Amigos()
    {
        InitializeComponent();
        presenter = new PresenterAmigos(this);
        presenter.ObtenerAmistades();
        presenter.ObtenerUsuarioActual();
        usuarioactual = System.Threading.Thread.CurrentPrincipal.Identity.Name;
    }
    
    public string usuarioactual
    {
        get { return (string)GetValue(usuarioactualProperty); }
        set { SetValue(usuarioactualProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for usuarioactual.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty usuarioactualProperty =
        DependencyProperty.Register("usuarioactual", typeof(string), typeof(Amigos), new UIPropertyMetadata(string.Empty));
