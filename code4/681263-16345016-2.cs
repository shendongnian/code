    var propertyAccessors = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
                                .SelectMany(p => p.GetAccessors())
                                .Cast<MemberInfo>();
    var eventAccessors = type.GetEvents(BindingFlags.Static | BindingFlags.Public)
                             .SelectMany(e => new[] {
                                 e.GetAddMethod(true),
                                 e.GetRemoveMethod(true)
                             })
                             .Cast<MemberInfo>();
    var accessors = propertyAccessors.Concat(eventAccessors);
    var memberList = type.GetMembers(BindingFlags.Static | BindingFlags.Public)
                         .Except(accessors);
