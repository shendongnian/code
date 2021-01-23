        namespace MyProject.Models
        {
            public partial class ReAdvSlot
                {
                    public int AdvSlotId { get; set; }
                    public string Name { get; set; }
                    public string Description { get; set; }
                    public bool IsPublished { get; set; }
                    public string Code { get; set; }
                    public string Notes { get; set; }
                }
            }
        }
        namespace MyProject.Models
        {
            [MetadataType(typeof(ReAdvSlotMetaData))]
            public partial class ReAdvSlot
            {
                 public string TestProperty { get; set; } // TEST PROPERTY here instead
            }
            public class ReAdvSlotMetaData
                {
                    [Required] //Example of defining metadata
                    public int AdvSlotId { get; set; }
                    public string Name { get; set; }
                    public string Description { get; set; }
                    public bool IsPublished { get; set; }
                    public string Code { get; set; }
                    public string Notes { get; set; }
                   
                }
        }
