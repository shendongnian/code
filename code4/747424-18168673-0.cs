            using Microsoft.CSharp.RuntimeBinder;
            var p = Expression.Parameter(typeof(OuterClass), "p");
            var binder = Binder.GetMember(CSharpBinderFlags.None, "Value", outer.Inner.GetType(), new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var e = Expression.Lambda<Func<OuterClass, object>>(
                Expression.Dynamic(binder, typeof(object) ,Expression.Property(p, "Inner")),
                p
            ).Compile();
