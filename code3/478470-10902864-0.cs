    namespace NewOrbit.ExVerifier.Model.Workflow.Case
    {
        using System;
        using System.ServiceModel;
    
        using NewOrbit.ExVerifier.Model.Workflow;
    
        [ServiceContract(Namespace = "urn://exverifier.neworbit.co.uk/")]
        public interface ICaseWorkflow
        {
            [OperationContract(Action = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/Start",
                ReplyAction = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/StartReply")]
            [return: MessageParameter(Name = "result")]
            WorkflowInstanceIdentifier Start(int caseID);
            
            [OperationContract(Action = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/ApplicationStateChanged",
                ReplyAction = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/ApplicationStateChangedReply")]
            [return: MessageParameter(Name = "result")]
            bool ApplicationStateChanged(Guid instanceID, int applicationID);
    
            [OperationContract(Action = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/Cancel",
                ReplyAction = "urn://exverifier.neworbit.co.uk/NewOrbit.ExVerifier.Model.Workflow.Case.ICaseWorkflow/CancelReply")]
            [return: MessageParameter(Name = "result")]
            bool Cancel(Guid instanceID);
        }
    }
