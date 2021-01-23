    namespace Extensions.Satellite
    {
        // SatVm
        public static void MakeValid<TParentModel, TModel>(this ISatelliteVm<TParentModel, TModel> instance, IEntityValidator validator) {...}
    }
    namespace Extensions.Hub
    {
        // HubVm
        public static void MakeValid<TParentModel>(this HubViewModel<TParentModel> instance, IEntityValidator validator, bool bValid = true)
            where TParentModel : Entity {   ... }
    }
    namespace Extensions.Wrapper
    {
        // VmWrapper    
        public static void MakeValid<TModel>(this ViewModelWrapper<TModel> instance, IEntityValidator validator) { ... }
    }
