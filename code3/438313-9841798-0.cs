    public class TrackDirtyPropertyAttribute : OnMethodBoundaryAspect 
    { 
        public override void OnSuccess(MethodExecutionArgs args) 
        { 
            ((BaseModel) args.Instance).IsDirty = true; 
        } 
    } 
