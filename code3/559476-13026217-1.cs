    public class MyObjectEditor : CollectionEditor {
        public MyObjectEditor(Type type) : base(type) { }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
                       
            return ((MyObject)context.Instance).Items;
        }
    }
