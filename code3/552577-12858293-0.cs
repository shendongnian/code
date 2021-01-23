    public class JsonParameterAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new TypedJsonBinder();
        }
    }
