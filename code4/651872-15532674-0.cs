    class MyInspector : ExplicitlyDeclaredModel {
        public override bool IsEntity(Type type) {
            if (type == typeof (BusinessContact))
                return false;
            return base.IsEntity(type);
        }
    }
    var mapper = new ModelMapper(new MyInspector());
