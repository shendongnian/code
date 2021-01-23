    container.Register(
            Classes.FromThisAssembly().BasedOn<ICommandLineOptions>().Configure(
                c => c.UsingFactoryMethod((kernel, context) =>
                        Program.ParseOptions(Activator.CreateInstance(context.RequestedType))
                    )
                ));
