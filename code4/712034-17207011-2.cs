    public Calculator()
    {
        _container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        // This registers the instance _container as CompositionContainer
        _container.ComposeExportedValue<CompositionContainer>(_container);
        _container.SatisfyImportsOnce(this);
        _buttons = new List<ICalculatorButton>();
    ...
    [ImportingConstructor]
    public Add(CompositionContainer container)
    {...}
