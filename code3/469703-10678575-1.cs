    public partial class ChildStateManager : IStateManager<Child, MyObjContext>
    {
    
        public void ChangeState(Child m, MyObjContext ctx)
        {
            if (m == null) return;
            ctx.Children.Attach(m);
            if (m.IsDeleted)
            {
                ctx.ObjectStateManager.ChangeObjectState(m, System.Data.EntityState.Deleted);
            }
            else
            {
                if (m.IsNew)
                {
                    ctx.ObjectStateManager.ChangeObjectState(m, System.Data.EntityState.Added);
                }
                else
                {
                    if (m.IsDirty)
                    {
                        ctx.ObjectStateManager.ChangeObjectState(m, System.Data.EntityState.Modified);
                    }
                }
            }
            SetRelationsState(m, ctx);
        }
        private void SetRelationsState(Child m, MyObjContext ctx)
        {
        }
    }
