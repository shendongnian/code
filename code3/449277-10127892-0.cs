    partial class Item
    {
         public static Expression<Func<Item, bool>> IsSpecial = (i => Math.Sqrt(i.Id)%2==0);
    }
    datacontext.Item.Where(Item.IsSpecial)
