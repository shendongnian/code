        public class ShopMaterial
        {
            public int Id {get;set;}
            public string Name {get;set;}
        }
        public class ShopItem 
        {
            public string ShopItemName { get; set; }
            public HashSet<ShopMaterial> ShopMaterialList { get; set; }
        }
