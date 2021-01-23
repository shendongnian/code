    class MainClass
    {
      public static void Main()
      {
        ShowMeHowToDoIt show = new ShowMeHowToDoIt();
        show.Add( new TheType() );
	  
        foreach ( var item in show.Items )
        {
	   Console.WriteLine( item );
        }	  
      }
    }
    public class ShowMeHowToDoIt
    {
      private List<TheType> items = new List<TheType>();
   
      public void Add( TheType item ) { items.Add( item ); }
      public IEnumerable<IType> Items
      {
        get { return items; }
      }
    }
    public interface IType { }
    public class TheType : IType { }
