    [ServiceContract]
    public interface IFingerprintContrat {
      
       [OperationContract]
       Fmd[] GetLastFeature(); 
      
    }
    public class FingerprintService {
      Fmd[] GetLastFeature() {
         return CaptureAndExtractFmd().ToArray()
      }
    }
    using (ServiceHost host = new ServiceHost(typeof(FingerprintService), baseAddress))
    {
    // Enable metadata publishing.
      ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
      smb.HttpGetEnabled = true;
      smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
      host.Description.Behaviors.Add(smb);
      host.Open();
      Console.WriteLine("The service is ready at {0}", baseAddress);
      Console.WriteLine("Press <Enter> to stop the service.");
      Console.ReadLine();
      // Close the ServiceHost.
      host.Close();
    }
    
