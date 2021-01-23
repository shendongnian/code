    class ImplementationWrapper : ITypeA<IType2>
    {
        public ImplementationA<ImplementationB> MyObject { get; set; }
    }
    public ITypeA<IType2> MyProperty {
        get {
            return new ImplementationWrapper {
                MyObject = new ImplementationA<ImplementationB>()
            };
       }
    }
