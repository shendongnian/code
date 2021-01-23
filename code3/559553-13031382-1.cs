    public class Shop
    {
       /// Shop Object
       public string Shop { get; set; }
       public List<Item> Items { get; set; }
    }
    public class Item
    {
       ///Items Object
       public string Name { get; set; }
       public string Picture { get; set; }
    }
    public List<Item> ItemsList(int id)
    {
       var item = from i in DB.Items
       where i.ShopId == id
       select new ShopItem
       {
          Name = i.Name,
          Picture = i.ItemPictures
       };
      return item.ToList();
    }
    public List<Shop> ShopItems(int ShopId)
    {
       var Shopitms = from shop in DB.Shops
       where shop.Id == ShopId && shop.IsActive == true && shop.IsDeleted == false
       select new Shop
       {
          Shop = shop.Name,
          Items = ItemsList(shop.Id)
       }
    return ShopItms.ToList();
    }
