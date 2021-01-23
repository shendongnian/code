    namespace MyProjectName.Models
    {
    
        public class ContractMeta
        {
            [Display(Name = "CP ContractID")] // abbreviation shown in Html.DisplayNameFor
            public string CounterpartyContractID;
    
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]  // format used by Html.EditorFor
            public DateTime EffectiveDate;
        }
    
        [MetadataType(typeof(ContractMeta))]
        public partial class Contracts
        {
    
        }
    }
