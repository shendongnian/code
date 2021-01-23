        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
        [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "BaseService.IBaseSvc")]
        public interface IBaseSvc2
        {
            [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBaseSvc/Version", ReplyAction = "http://tempuri.org/IBaseSvc/VersionResponse")]
            [WebGet]
            VersionInformation Version();
        }
