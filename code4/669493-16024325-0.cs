    class Program
    {
        static void Main(string[] args)
        {
            InventoryDAL inv = new InventoryDAL(@"Data Source=MYPC;Initial     Catalog=AutoLot;Integrated Security=True;Pooling=False");
            DataTable dt = inv.Inventory();
           dt.Rows[0].Delete();
           inv.UpdateInventory(dt);
           Console.ReadKey(true);
    }}
