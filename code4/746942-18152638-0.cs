    public interface IStandardTemplate<TModel> { }
    public interface IModelBinder<TModel>
    {
         TModel ApplyParameters(IStandardTemplate<TModel> template, params object[] parameters);
    }
    public class ModelBuilder
    {
          public TModel Build<TModel>(IStandardTemplate<TModel> template, params object[] parameters)
          {
              var model = Activator.CreateInstance<TModel>();
  
              var modelBinder = ModelBinderFactory.CreateBinderFor(model);
              return modelBinder.ApplyParameters(template, parameters);
          }
    }
