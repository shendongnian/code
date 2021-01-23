    public class RepositoryBase<TPoco>
    //...
    public virtual OperationResult Add(TPoco poco)
    var entityQA = poco as IFQuickAudit;
            if (entityQA != null) {
                 entityQA .CreatedBy = userId;
                 entityQA .CreatedOn = when;
            }
    // checks...
    Context.Set<TPoco>().Add(poco);
    // similar for Chnage routine
