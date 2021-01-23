using (var ctx = new context())
{
    ctx.Connection.Open();
    ctx.Transaction = ctx.Connection.BeginTransaction();
    ctx.Entities.InsertOnSubmit(itemDB);
    ctx.SubmitChanges();
    ctx.Refresh(RefreshMode.OverwriteCurrentValues, itemDB);
    Model newModel = itemDB.ToModel();
    ctx.Transaction.Commit();
    return newModel;
}
catch (Exception ex)
{
    ctx.Transaction.Rollback();
}
