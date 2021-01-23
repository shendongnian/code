    public class Car: IEquatable<Car>
    {
        ......
       
        public bool Equals( Car other )
        {
            return this.CarID  == other.CarID && this.CarName == other.CarName;
        }
    }
