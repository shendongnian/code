        namespace NamespaceOfYourProject
        {
            [Guid("add a GUID here")]
            public interface IInterface
            {
                void Connect();
                void Disconnect();
            }
        }
        namespace NamespaceOfYourProject
        {
             [Guid("add a GUID here")]
             public class ClassYouWantToUse: IInterface
             {
                 private bool connected;
                 public void Connect()
                 {
                     //add code here
                 }
                 public void Disconnect()
                 {
                     //add code here
                 }
        }
