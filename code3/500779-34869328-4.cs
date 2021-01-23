        public class NullModelAttribute : CustomModelBinderAttribute
        {
            public override IModelBinder GetBinder()
            {
                return new NullModelBinder();
            }
        }
