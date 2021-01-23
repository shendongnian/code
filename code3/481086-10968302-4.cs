    abstract class Node
    {
       abstract void Move();
    }
    abstract class NodeMoving : Node
    {
       abstract bool IsValid();
    }
    abstract class NodeMovingLeft : NodeMoving
    {
       override void Move()
       {
          // add code to move left
          if(this.IsValid())
          {
             // move
          }
       }
    }
    abstract class NodeMovingRight : NodeMoving
    {
       override void Move()
       {
          // add code to move right
          if(this.IsValid())
          {
             // move
          }
       }
    }
    // and then start modeling the different states
    class RightFree : NodeMovingRight
    {
       override bool IsValid()
       {
          // add condition to validate if the right is free
       }
    }
    // combining conditions
    class PushedLeft : NodeMovingLeft
    {
       override bool IsValid()
       {
          // code to determine if it has been pushed to the left
       }
    }
    class LeftFree : PushedLeft
    {
       override bool IsValid()
       {
          // get condition to indicate if the left is free
          var currentCondition = GetCondition();
          // combining the conditions
          return currentCondition && base.IsValid();
       }
    }
