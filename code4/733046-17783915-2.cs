    foreach (var item in objects.OfType<SubClassOne>())
    {
       item.Main();
    }
       
    foreach (var item in objects.OfType<SubClassTwo>())
    {
       item.Main();
    }
       
