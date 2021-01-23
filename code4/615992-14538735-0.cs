    public DisplayAttribute MyVMPropertyDisplayAttribute
    {
        get
        {
            var prop = typeof(MyModels.Model).GetProperty("MyProperty");
            var attr = prop.GetCustomAttributes(typeof(DisplayAttribute));
            return attr.Cast<DisplayAttribute>().Single();
        }
    }
