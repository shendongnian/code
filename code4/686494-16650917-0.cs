    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
    using System;
    using System.Linq;
    [ConfigurationElementType(typeof (CustomLogFilterData))]
    public class RhinoFilter : LogFilter
    {
        public RhinoFilter(string name)
            : base(name)
        {
        }
        public RhinoFilter(NameValueCollection settings) 
            : this("RhinoFilter")
        {
        }
        public override bool Filter(LogEntry log)
        {
            return log.Categories.Any(x => x.StartsWith("Rhino."));
        }
    }
