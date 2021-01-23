    // Custom comparer for the class 
     class CarComparer : IEqualityComparer<Car>
    {
    // Products are equal if their names and product numbers are equal. 
    public bool Equals(Car x, Car y)
    {
        //Check whether the compared objects reference the same data. 
        if (Object.ReferenceEquals(x, y)) return true;
        //Check whether any of the compared objects is null. 
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;
        //Check whether the properties are equal. 
        return x.CarID == y.CarID && x.CarName == y.CarName;
    }
    // If Equals() returns true for a pair of objects  
    // then GetHashCode() must return the same value for these objects. 
    public int GetHashCode(Car car)
    {
        //Check whether the object is null 
        if (Object.ReferenceEquals(car, null)) return 0;
        //Get hash code for the Name field if it is not null. 
        string hashCarName = car.CarName == null ? 0 : car.CarName.GetHashCode();
        //Get hash code for the ID field. 
        int hashCarID = car.CarID.GetHashCode();
        //Calculate the hash code for the product. 
        return hashCarName ^ hashCarID;
    }
