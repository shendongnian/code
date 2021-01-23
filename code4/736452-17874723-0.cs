        static void Main(string[] args)
        {
            TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ClientInfoView), typeof(ClientInfoViewMetaData)), typeof(ClientInfoView));
            ClientInfoView cv1 = new ClientInfoView() { ID = 1 };
            var df = cv1.GetType().GetCustomAttributes(true);
            var dfd = cv1.ID.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), true);
            var context = new ValidationContext(cv1, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject( cv1,context, results, true);
        }
    }
    
        [MetadataType(typeof(ClientInfoViewMetaData))]
        public partial class ClientInfoView
        {
            public int ID { get; set; }
            public string Login { get; set; }
        }
    public class ClientInfoViewMetaData
    {        
        [Required]
        [Category("Main Data"), DisplayName("Client ID")]
        public int ID { get; set; }
                
        [Required]
        [Category("Main Data"), DisplayName("Login")]
        public string Login { get; set; }
    
    }
