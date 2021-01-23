    ReportGenerator generator = new ReportGenerator();
    // 1. Invoke method with single parameter
    foreach(Type t in ReportsTypes) {
        generator.InitilizeReportsByType(t);
    }
    // 2. Make and invoke generic method without parameter via reflection
    foreach(Type t in ReportsTypes) {
        MethodInfo genericMethod = mInfo.MakeGenericMethod(new Type[] { t });
        genericMethod.Invoke(generator, new object[] { });
    }
    
    
    public class ReportGenerator {
        public void InitilizeReportsByType(Type type) {
            IReportDocument reportDocument = (IReportDocument)Activator.CreateInstance(type);
            //...
        }
        public void InitilizeReportsGeneric<T>() where T : IReportDocument, new() {
            T reportDocument = new T();
            //...
        }
    }
