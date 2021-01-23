      public interface IContainer<out T> where T : MyBaseRow
      {
        
      }
    
      public class MyContainer<T> : IContainer<T> where T : MyBaseRow
      {
    
      }
    
      public abstract class MyBaseRow
      {
        public IContainer<MyBaseRow> ParentContainer;
    
        public MyBaseRow(IContainer<MyBaseRow> parentContainer)
        {
          ParentContainer = parentContainer;
        }
      }
    
      public class MyInheritedRowA : MyBaseRow
      {
        public MyInheritedRowA(IContainer<MyInheritedRowA> parentContainer)
          : base(parentContainer)
        { }
      }
