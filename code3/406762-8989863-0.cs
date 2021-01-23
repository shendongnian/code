    public interface IBaseStepHandler<out T> // "out" marks T as contravariant
       where T : BaseDataModel // Do you have a model base type? ;)
    {
         // Declare members here
    }
