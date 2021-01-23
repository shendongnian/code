    using MyProject.<whatever>
    public class MyController
    {
      public ActionResult Edit(int id)
      {
        var item= DB.GetRow(id) //whatever that looks like    
        if (!this.User.IsAdminOrDomainAc(item.DomainAC))
        {
          return this.RedirecToAction("Index");
        }
        return this.View(item);
      }
