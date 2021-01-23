        private const int FactoryMode = 11;
        private const int SingletonMode = 10;
        public static void Main()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ComplexTypeScope>().SingleInstance();
            containerBuilder.Register((c, p) => c.Resolve<ComplexTypeScope>().Get(p.TypedAs<int>()));
            var container = containerBuilder.Build();
            ComplexType instance1 = container.Resolve<ComplexType>(new TypedParameter(typeof(int), SingletonMode));
            ComplexType instance2 = container.Resolve<ComplexType>(new TypedParameter(typeof(int), SingletonMode));
            ComplexType instance3 = container.Resolve<ComplexType>(new TypedParameter(typeof(int), FactoryMode));
            Debug.Assert(ReferenceEquals(instance1, instance2));
            Debug.Assert(!ReferenceEquals(instance1, instance3));
        }
        class ComplexType
        {
        }
        class ComplexTypeScope
        {
            private readonly Lazy<ComplexType> complexTypeSingleTon;
            public ComplexTypeScope()
            {
                complexTypeSingleTon = new Lazy<ComplexType>(() => new ComplexType());
            }
            public ComplexType Get(int parameter)
            {
                return parameter == FactoryMode ? new ComplexType() : complexTypeSingleTon.Value;
            }
        }
