    public class SomeTypeEditor : CollectionEditor {
        public SomeTypeEditor(Type type) : base(type) { }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
                       
            return ((ClassContainingStuffProperty)context.Instance).Items;
        }
    }
