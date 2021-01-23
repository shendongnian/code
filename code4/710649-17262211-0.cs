    public class SuperPower
    {
        public string Name { get; set; }
    }
    [MetadataType(typeof(UnicornViewModel.UnicornViewModelMetaData))]
    public class UnicornViewModel
    {
        public string Name { get; set; }
        public RequiredSuperPowerViewModel PrimarySuperPower { get; set; }
        public SuperPower SecondarySuperPower { get; set; }
        public class UnicornViewModelMetaData
        {
            [Required]
            public string Name { get; set; }
        }
    }
    [MetadataType(typeof(UnicornViewModel.UnicornViewModelMetaData))]
    public class RequiredSuperPowerViewModel : SuperPower
    {
        public class RequiredSuperPowerModelMetaData
        {
            [Required]
            public string Name { get; set; }
        }
    }
