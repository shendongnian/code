    var widgetContainer = context.WidgetContainers.Find(1);
    // or:
    // var widgetContainer = context.WidgetContainers.Create();
    // widgetContainer.Id = 1;
    // context.WidgetContainers.Attach(widgetContainer);
    widgetContainer.SetComplete();
    context.SaveChanges();
