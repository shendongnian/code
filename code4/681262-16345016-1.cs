    var propertyAccessors = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
                                .SelectMany(p => p.GetAccessors())
                                .Cast<MemberInfo>();
    var eventAccessors = type.GetEvents(BindingFlags.Static | BindingFlags.Public)
                             .SelectMany(e => new[] { e.AddMethod, e.RemoveMethod })
                             .Cast<MemberInfo>();
    var accessors = propertyAccessors.Concat(eventAccessors);
    var memberList = type.GetMembers(BindingFlags.Static | BindingFlags.Public)
                         .Except(accessors);
