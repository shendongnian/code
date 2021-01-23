    using System.Web.Mvc;
    using ModelBinder.Controllers;
    
    public class ConfirmationModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = new ConfirmationModel();
    
            var transactionNumberParam = bindingContext.ValueProvider.GetValue("t_numb");
    
            if (transactionNumberParam != null)
                model.TransactionNumber = transactionNumberParam.AttemptedValue;
            
            return model;
        }
    }
