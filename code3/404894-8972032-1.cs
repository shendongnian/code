    public class MyBusinessController : MyBusinessControllerBase, IMyBusinessController
    {
        [Log(LoggingLevel.Debug)]
        public virtual ActionResult CreateOrUpdate(MyBusinessFormModel fm)
        {
            // Convert form model to data transfer object,
            // perform validation and other checks
            this.service.Save(dto);
            return View(fm);
        }
    }
