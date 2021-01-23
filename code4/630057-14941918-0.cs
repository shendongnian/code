    public class ExhibitionItemModel
    {   
        
        public ExhibitionItemModel(){
            Exhibition = new tblExhibition();
            ExhibitionItems = new List<tblExhibitonItem>();
            Items = new List<ItemWrapper>();
        }
        public IEnumerable<ItemWrapper> Items { get; set; }
        public tblExhibition Exhibition { get; set; }
        public IEnumerable<tblExhibitionItem> ExhibitionItems { get; set; }
    }    
