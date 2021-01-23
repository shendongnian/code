    public class Loader {
       private ItemsToLoad Items { get; set; }
       protected virtual ItemsToLoad CreateItemsToLoad() {
          return new ItemsToLoad();
       }
       protected class ItemsToLoad {
          public virtual void Add() {
          }
       }
    }
    public class MyOtherLoader : Loader {
       protected override ItemsToLoad CreateItemsToLoad() {
          return new MyOtherItemsToLoad();
       }
       private class MyOtherItemsToLoad : ItemsToLoad {
          public override void Add() {
          }
       }
    }
