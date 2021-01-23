    public interface INodeAddable {
       void AddNode(TreeNode node);
    }
    
    public class Form1 : INodeAddable
    {
        private void SomeMethod()
        {
            var f2 = new Form2(this);
        }
    
        public void AddNode(TreeNode n)
        {
           // add node to tree
        }
    }
    
    public class Form2
    {
      private INodeAddable x;
      public Form2(INodeAddable x)
      {
        this.x = x;
      }
    
      public void SomeEventHandler(object sender, EventArgs e)
      {
         x.AddNode(someNewNode);
      }
    }
