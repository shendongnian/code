    public interface IFruitPage<out T> where T : Fruit {
        public T MyFruit { get; }
    }
    public class FruitPage<T> : Page, IFruitPage<T> where T : Fruit {
        public T MyFruit { get; set; }
    }
   
    public class FoodMaster : MasterPage {
        protected override void OnLoad(EventArgs e) {
           base.OnLoad(e);
    
           var fruitPage = this.Page as IFruitPage<Fruit>;
           if (fruitPage != null && fruitPage.MyFruit.ID <= 0) {
              ...
           }
        }
    }
