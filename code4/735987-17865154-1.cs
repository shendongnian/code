    builder.RegisterType<ListItemA>().As<IListItem>().WithOrder();
    builder.RegisterType<ListItemB>().As<IListItem>().WithOrder();
    builder.RegisterType<OrderedListWorker>()
    			       .As<IListWorker>()
    			       .WithParameter(
    				       new ResolvedParameter(
    					       (info, context) => true,
    					       (info, context) => context.ResolveOrdered<IListItem>()));
