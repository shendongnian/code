    var memberEntry = this.Entry(entity).Member("NavigationProperty");
    if (memberEntry is DbCollectionEntry)
        ((DbCollectionEntry)memberEntry).Load();
    if (memberEntry is DbReferenceEntry)
        ((DbReferenceEntry)memberEntry).Load();
