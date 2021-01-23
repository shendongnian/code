      child1.RegisterType<IA1, A1>( 
         new InjectionFactory( container => 
             {
                 // arbitrarily complicated imperative code to create an instance
                 // first resolve ISimpleSessionFactory by name
                 ISimpleSessionFactory factory = 
                    container.Resolve<ISimpleSessionFactory>( "ContainerA" );
                 // then create A1
                 return new A1( factory, any, other, parameters, here );
             }
         ) );
