    public abstract class AVM : MvxViewModel {
        private static readonly Dictionary<Guid, WeakReference> ViewModelCache = new Dictionary<Guid, WeakReference>();
        private static readonly string BUNDLE_PARAM_ID = @"AVM_ID";
        private Guid AVM_ID = Guid.NewGuid();
        private Type MyType;
        protected AVM()
        {
            MyType = this.GetType();
            ViewModelCache.Add(AVM_ID, new WeakReference(this));
        }
        public static bool TryLoadFromBundle(IMvxBundle bundle, out IMvxViewModel viewModel)
        {
            if (null != bundle && bundle.Data.ContainsKey(BUNDLE_PARAM_ID))
            {
                var id = Guid.Parse(bundle.Data[BUNDLE_PARAM_ID]);
                viewModel = TryLoadFromCache(id);
                return true;
            }
            viewModel = null;
            return false;
        }
        private static IMvxViewModel TryLoadFromCache(Guid Id)
        {
            if (ViewModelCache.ContainsKey(Id))
            {
                try
                {
                    var reference = ViewModelCache[Id];
                    if (reference.IsAlive)
                        return (IMvxViewModel)reference.Target;
                }
                catch (Exception exp) { Mvx.Trace(exp.Message); }
            }
            return null;
        }
        protected void View()
        {
            var param = new Dictionary<string, string>();
            param.Add(BUNDLE_PARAM_ID, AVM_ID.ToString());
            ShowViewModel(MyType, param);
        }
