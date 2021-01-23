    var memberEntry = this.Entry<Entity>(entity).Member("NavigationProperty");
    if (memberEntry is DbCollectionEntry)
        ((DbCollectionEntry)memberEntry).Load();
    if (memberEntry is DbReferenceEntry)
        ((DbReferenceEntry)memberEntry).Load();
