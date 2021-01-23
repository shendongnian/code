    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    
    namespace PropertyGrid_ListBox_Test
    {
        class TestCase
        {
            public TestCase()
            {
                Manufacturer = new List<TypeCodes>();
            }
    
            [DisplayName("Manufacturer Preparation Type Code")]
            public List<TypeCodes> Manufacturer { get; set; }
        }
    }
