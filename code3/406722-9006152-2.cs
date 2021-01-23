    public abstract class CategoryAttributeVM 
    { 
        <...>
        public abstract void UpdateValueFrom(CategoryAttributeVM sourceCategoryAttributeVM);
    } 
    public abstract class CategoryAttributeVM<T> : CategoryAttributeVM 
    {
        <...>
        public override void UpdateValueFrom(CategoryAttributeVM sourceCategoryAttributeVM)
        {
            if (GetType() == sourceCategoryAttributeVM.GetType())
                Value = (T)sourceCategoryAttributeVM.Value;
        }
    }
