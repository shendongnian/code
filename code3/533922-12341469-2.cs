    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ExampleLibrary
    {
        class InventoryType 
        { 
 
            /// <summary> 
            /// Selects the inventory type and returns the selected value 
            /// </summary> 
            public class InventorySelect 
            { 
                private string inventoryTypes; 
                public String InventoryTypes 
                { 
                    set 
                    { 
                        inventoryTypes = value; 
                    } 
 
                    get 
                    { 
                        return inventoryTypes; 
                    } 
                } 
 
 
                /// <summary> 
                /// Validate that the inventory is returning some sort of value 
                /// </summary> 
                /// <returns></returns> 
                public bool Validate() 
                { 
                    if (InventoryTypes == null) return false; 
                    return true; 
                } 
            } 
        }
    }
