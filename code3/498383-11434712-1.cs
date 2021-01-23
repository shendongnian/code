    // using SimpleInjector.Extensions;
    var container = new Container();
    container.RegisterOpenGeneric(
        typeof(IRenderer<>), 
        typeof(SampleGenericRenderer<>));
    // Usage
    var renderer =
        container.GetInstance<IRenderer<Generic<string>>>();
    renderer.Render(new Generic<string>());
