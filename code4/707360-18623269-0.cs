    public partial class DemoService
    {
        partial void OnContextCreated()
        {
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
    }
