    abstract DataModel {
    
    }
    
    class LoginStepOneDataModel : DataModel {
    
    }
    
    class RegularDemoAccountStepOneDataModel : DataModel {
    
    }
    
    public abstract class BaseStepHandler{
      protected abstract HandlerResult Handle(StepHandlerWrapper<DataModel>);
    }
