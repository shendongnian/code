    namespace HomeInventory2.Business
    {
        public class InventoryMngr : Manager
        {
            /// <summary>
            /// persists the inventory information
            /// </summary>
            /// <param name="inv"></param>
            public void Create(CreateInventory inv)
            {
                InventorySvc inventorySvc =
                (InventorySvc)GetService(typeof(InventorySvc));
                inventorySvc.CreateInventory(inv);
            }
        }
    }
