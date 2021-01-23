    [MetadataType(typeof(ClientViewModel.ClientMetaData))]
    public class ClientViewModel : Client
    {
        internal class ClientMetaData
        {
            [Display(ResourceType = typeof(ResourceStrings), Name = "Client_FirstName_Label")]
            public string FirstName { get; set; }
        }
    }
