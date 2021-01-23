    public class Parent 
    { 
        public virtual void Draw()
        {
           // parent implementation of Draw
        }
    }
    
    public class Child1 : Parent
    { 
        public override void Draw()
        {
            // child1 implementation of Draw
        }
    }
    
    public class Child2 : Parent
    { 
        public override void Draw()
        {
            // use base.Draw() to call parent implementation
            // child2 implementation of Draw
        }
    }
