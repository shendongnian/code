    var depPropGetter = typeof (Validation).GetField("ValidationAdornerProperty", BindingFlags.Static | BindingFlags.NonPublic);
    var validationAdornerProperty = (DependencyProperty)depPropGetter.GetValue(null);
    var adorner = (Adorner)DateActionDone.GetValue(validationAdornerProperty);
    if (adorner != null && Validation.GetHasError(MyControl))
    {
        var adorners = AdornerLayer.GetAdornerLayer(MyControl).GetAdorners(MyControl);
        if (adorners.Contains(adorner))
            AdornerLayer.GetAdornerLayer(MyControl).Remove(adorner);
    }
    
