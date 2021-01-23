    abstract class Node
    {
       abstract void Move();
    }
    abstract class NodeMovingLeft : Node
    {
       override void Move()
       {
          // add code to move left
       }
    }
    abstract class NodeMovingRight : Node
    {
       override void Move()
       {
          // add code to move right
       }
    }
    interface IHandleCondition
    {
       bool IsValid();
       void Execute();
    }
    // and then start modeling the different states
    class RightFree : NodeMovingRight, IHandleCondition
    {
       public virtual bool IsValid()
       {
          // add condition to validate if the right is free
       }
       public virtual void Execute()
       {
          // execute the movement
          if(this.IsValid())
          {
             this.Move();
          }
       }
    }
    // combining conditions
    class PushedLeft : NodeMovingLeft, IHandleCondition
    {
       public virtual bool IsValid()
       {
          // code to determine if it has been pushed to the left
       }
       public virtual void Execute()
       {
          if(this.IsValid()) this.Move();
       }
    }
    class LeftFree : PushedLeft, IHandleCondition
    {
       public virtual bool IsValid()
       {
          // get condition to indicate if the left is free
          var currentCondition = GetCondition();
          // combining the conditions
          return currentCondition && base.IsValid();
       }
       public virtual void Execute()
       {
          if(this.IsValid()) this.Move();
       }
    }
