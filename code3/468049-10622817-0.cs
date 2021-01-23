    public class FruitPage : System.Web.UI.Page {
       public Fruit MyInnerFruit { get; protected set; }
    }
    public abstract class FruitPage<T> : System.Web.UI.Page where T : Fruit
    {
       public T MyFruit { 
         get { return (T)MyInnerFruit; } 
         set { MyInnerFruit = value; } 
       }
    }
    public partial class FoodMaster : System.Web.UI.MasterPage {
        protected override void OnLoad(EventArgs e) {
           base.OnLoad(e);
           var fruitPage = this.Page as FruitPage;
           if (fruitPage != null && fruitPage.MyInnerFruit.ID <= 0) {
              ...
           }
        }
    }
