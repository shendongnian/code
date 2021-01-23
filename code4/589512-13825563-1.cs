    container.Register(Component.For<IDocument>()
                       .ImplementedBy<Document>()
                       .DynamicParameters( 
                           (k, d) =>
                           {
                               // ask for an IDataSource, passing along any inline
                               // parameters that were supplied in the request for 
                               // an IDocument
                               var ds = k.Resolve<IDataSource>(d);
                               // Add it to the dictionary.  This makes it available
                               // for use when resolving other dependencies in the tree.
                               d.Add("DataSource", ds);
                               // Finally, pass back a delegate which can be used to release it
                               return (r) => r.ReleaseComponent(ds);
                           }));
