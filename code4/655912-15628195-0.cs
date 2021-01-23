    private static readonly Dictionary<DriveTrain, DriveTrainKind> DriveTrainKindMap = 
        Enums.GetValues<DriveTrain>().ToDictionary(d => d, d => d.GetDriveTrainKind());
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DriveTrainKindAttribute : Attribute
    {
        public DriveTrainKindAttribute(DriveTrainKind kind)
        {
            Kind = kind;
        }
        public DriveTrainKind Kind { get; private set; }
    }
    public static class ExtensionMethods
    {
        public static DriveTrainKind GetDriveTrainKind(this DriveTrain value)
        {
            var fieldInfo = typeof(DriveTrain).GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DriveTrainKindAttribute), false)
                                      .Cast<DriveTrainKindAttribute>();
            return attributes.Select(a => a.Kind).SingleOrDefault();
        }
    }
    public enum DriveTrainKind : byte
    {
        ConventionalOrHybrid = 0,
        PluginHybrid = 1,
        BatteryElectric = 2,
    }
    public enum DriveTrain : short 
    {
        [Description("konv_otto"), DriveTrainKind(DriveTrainKind.ConventionalOrHybrid)]
        ConventionalGasoline = 0,
        [Description("konv_diesel"), DriveTrainKind(DriveTrainKind.ConventionalOrHybrid)]
        ConventionalDiesel = 1,
        ...
    }
