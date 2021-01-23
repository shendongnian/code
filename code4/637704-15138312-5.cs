    [Serializable]
    public class BootSaleList : IDisplay
    {
        private List<BootSale> bootsales;
        public List<BootSale> ReturnList()
        {
            return bootsales;
        }
    }
