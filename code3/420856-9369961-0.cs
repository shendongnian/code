     public class TreeNode<TPayload>
     {
         TPayload NodeStateInfo{get;set;}
         public void AddChild(TreeNode<TPayload> a_node)
         {
             a_node.SetParent(this); // This is the part I hate
         }
     
         void SetParent(TreeNode<TPayload> a_parent)
         {
         }
     }
