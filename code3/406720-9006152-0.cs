    public abstract class CategoryAttributeVM 
    { 
        <...>
        public abstract void CopyValueFrom(CategoryAttributeVM sourceCategoryAttributeVM);
    } 
    public abstract class CategoryAttributeVM<T> : CategoryAttributeVM 
    {
        <...>
        public override void CopyValueFrom(CategoryAttributeVM sourceCategoryAttributeVM)
        {
            if (GetType() == sourceCategoryAttributeVM.GetType())
                Value = (T)sourceCategoryAttributeVM.Value;
        }
    }
