    public interface IModelBuilder<T, Model>
        where T : IStandardTemplateTemplate
        where Model : BaseModel
    {
        M Build<M>(T pTemplate, params object[] pParams) where M : Model;
    }    
    public class BusinessModelBuilder : IModelBuilder<IBusinessTemplate, BussinessModel>
    {
        public virtual M Build<M>(IBusinessTemplate pTemplate, params object[] pParams)
            where M : BussinessModel
        {
            var businessModel = Activator.CreateInstance<M>();
            // map data
            return businessModel;
        }
    }
