       1: public interface ITag 
       2: {
       3:     void WriteTag(string tagName = "ITag");
       4: } 
       5:  
       6: public class BaseTag : ITag 
       7: {
       8:     public virtual void WriteTag(string tagName = "BaseTag") { Console.WriteLine(tagName); }
       9: } 
      10:  
      11: public class SubTag : BaseTag 
      12: {
      13:     public override void WriteTag(string tagName = "SubTag") { Console.WriteLine(tagName); }
      14: } 
      15:  
      16: public static class Program 
      17: {
      18:     public static void Main() 
      19:     {
      20:         SubTag subTag = new SubTag();
      21:         BaseTag subByBaseTag = subTag;
      22:         ITag subByInterfaceTag = subTag; 
      23:  
      24:         // what happens here?
      25:         subTag.WriteTag();       
      26:         subByBaseTag.WriteTag(); 
      27:         subByInterfaceTag.WriteTag(); 
      28:     }
      29: } 
 
