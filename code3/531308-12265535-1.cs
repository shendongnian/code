    public interface IAction{
        public void doAction(ResponseDataModel model);
    }
    
    public class Action1 : IAction
    {
        public void doAction(ResponseDataModel model)
        {
            string coilId = "CC12345";
            model.Data = new { Coil = coilId, M3 = "m3 message", M5 = "m5 message" };
            model.Message = string.Format("Coil {0} sent successfully", coilId);
        }
    }
    
    class Class1
    {
        public ActionResult MillRequestCoil(IAction action)
        {
            var model = new ResponseDataModel();
            try
            {
                //specific code
                action.doAction(model);
            }
            catch (Exception ex)
            {
                model.Error = true;
                model.Message = ex.ToString();
            }
            return View(model);
        }
    }
