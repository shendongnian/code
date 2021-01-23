    public interface IMovement
    {
    void Move();
    }
    
    public abstract class CarsMovement : IMovement
    {
    
    public virtual void Move()
    {
    //default behavior for cars movement
    }
    }
    
    public class SuzukiCar : CarsMovement
    {
    public override void Move()
    {
    //Provide Implementation
    }
    }
    
    public abstract class HumanBeingMovement : IMovement
    {
    
    public virtual void Move()
    {
    //default behavior for human being movement
    }
    }
    
    public class Man : HumanBeingMovement
    {
    public override void Move()
    {
    //Provide Implementation
    }
    }
    
    public class Woman : HumanBeingMovement
    {
    public override void Move()
    {
    //Provide Implementation
    }
    }
