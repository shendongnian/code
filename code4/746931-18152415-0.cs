    public interface IModelBuilder<T, M>
        where T : IStandardTemplateTemplate
        where M : BaseModel
    {
        M Build<M>(T pTemplate, params object[] pParams);
    }
