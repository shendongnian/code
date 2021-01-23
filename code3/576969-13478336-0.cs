    public class GClass1 : KeyedCollection<string, GClass2>
    {
      public override string GetKeyForItem(GClass2 item);
      protected override void InsertItem(int index, GClass2 item)
      {
        string keyForItem = this.GetKeyForItem(item);
        if (keyForItem != null)
        {
            this.AddKey(keyForItem, item);
        }
        base.InsertItem(index, item);
    }
