    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class items
    {
    
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public itemsItem[] item {get; set;}    
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItem
    {
    
        public string id{get; set;} 
       
        public string descr{get; set;} 
      
        public string unit{get; set;} 
       
        public string vat{get; set;} 
        
        public decimal inprice{get; set;} 
      
        public byte isstock{get; set;} 
        
        public sbyte stock{get; set;} 
       
        public object paccount{get; set;} 
        
        public string ean{get; set;} 
        
        public byte type{get; set;} 
     
        public string producer{get; set;} 
        
        public string producer_itemno{get; set;} 
        
        public object package_height{get; set;} 
        
        public object package_depth{get; set;} 
        
        public object package_width{get; set;} 
        
        public object package_weight{get; set;} 
        
        public object stock_place{get; set;} 
        
        public string stock_warning{get; set;} 
      
        public object note{get; set;} 
       
        public byte bulky{get; set;} 
        
        public byte omit{get; set;} 
       
        public sbyte available{get; set;} 
       
        public ushort account{get; set;} 
        
        public ushort constracct{get; set;} 
       
        public ushort exportacct{get; set;} 
        
        public ushort eurevacct{get; set;} 
        
        public ushort euvatacct{get; set;} 
        
        public object supplierno{get; set;} 
       
        public byte show_in_webshop{get; set;} 
        
        public itemsItemPrice price{get; set;} 
       
    }
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItemPrice
    {   
        [System.Xml.Serialization.XmlElementAttribute("list-")]
        public itemsItemPriceList list{get; set;} 
        
        [System.Xml.Serialization.XmlElementAttribute("list-a")]
        public itemsItemPriceLista lista{get; set;} 
        
        [System.Xml.Serialization.XmlElementAttribute("list-w")]
        public itemsItemPriceListw listw { get; set; } 
       
    }
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItemPriceList
    {   
        [System.Xml.Serialization.XmlElementAttribute("from-")]
        public object from{get; set;} 
       
    }
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItemPriceLista
    {
        [System.Xml.Serialization.XmlElementAttribute("from-0")]
        public decimal from0{get; set;} 
        
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItemPriceListw
    {
        [System.Xml.Serialization.XmlElementAttribute("from-0")]
        public byte from0{get; set;} 
        
    }
