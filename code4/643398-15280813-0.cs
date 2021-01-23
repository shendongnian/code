    public class BaseModel
    {
        public string GetModelName()
        {
            return this.GetType().Name;
        }
    }
    class SubModel : BaseModel
    {
    }
    SubModel test = new SubModel();
    string name = test.GetModelName();
