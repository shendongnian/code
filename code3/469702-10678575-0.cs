    public partial class ParentStateManager : IStateManager<Parent, MyObjContext>
    {
    
        private IStateManager<Child, MyObjContext> _ChildStateManager = new ChildStateManager();
        public void ChangeState(Parent m, MyObjContext ctx)
        {
            if (m == null) return;
            ctx.Parents.Attach(m);
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
        private void SetRelationsState(Parent m, MyObjContext ctx)
        {
            foreach (Child varChild in m.Children.Where(p => !p.IsDeleted))
            {
                _ChildStateManager.ChangeState(varChild, ctx);
            }
            while (m.Children.Where(p => p.IsDeleted).Any())
            {
                _ChildStateManager.ChangeState(m.Children.Where(p => p.IsDeleted).LastOrDefault(), ctx);
            }
        }
    }
