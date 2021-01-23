    public interface IBaseStepHandler<out T> // "out" marks T as covariant
       where T : BaseDataModel // Do you have a model base type? ;)
    {
         // Declare members here
    }
