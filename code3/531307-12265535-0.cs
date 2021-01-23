    public interface Action{
        public void doAction(ResponseDataModel model);
    }
    
    public class Action1 : Action
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
        public ActionResult MillRequestCoil(Action action)
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
