    // concrete controller implementation
    public class Down_Time_CaptureController: ControllerBase<Down_Time_Capture, VM_Down_Time_Capture, Down_Time_CaptureRepository>
    {
    }
    // generic controller base
    public abstract class ControllerBase<TModel, TViewModel, TRepository>: Controller
            where TModel : Base_Model, new()
            where TViewModel : Base_ViewModel, new()
            where TRepository : Base_Repository, new()
    {
        protected virtual TModel CreateNewModel()
        {
               return (TModel)Activator.CreateInstance<TModel>();
        }
        protected virtual TRepository CreateNewRepository()
        {
               return (TRepository)Activator.CreateInstance<TRepository>();
        }
        protected virtual TViewModel CreateNewViewModel()
        {
                return (TViewModel)Activator.CreateInstance<TViewModel>();
        }
        //I'm assuming my generified add method would go in here  
        public virtual ActionResult Add(TViewModel viewModel)
        {
           using (var repository = CreateRepository())
           {
                   if (!ModelState.IsValid)
                       return ReturnValidationFailure(ViewData.ModelState.Values);
                   var model = CreateNewModel();
                   model.InjectFrom(viewModel);
                   string mserMsg = repository.Add(model, User.Identity.Name);
                   if (!string.IsNullOrEmpty(mserMsg))
                       return ReturnCustomValidationFailure(Server.HtmlEncode(mserMsg));
                   repository.Save();
                   return Json("Added successfully.", JsonRequestBehavior.AllowGet);
            }       
        }
    }
