    using System;
    using System.EnterpriseServices;
    [assembly: ApplicationName("Calculator")]
    [assembly: ApplicationActivation(ActivationOption.Library)]
    public class Calculator : ServicedComponent
    {
        public int Add(int x, int y){ return (x + y); }
    }
