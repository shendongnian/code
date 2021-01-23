	public class EmployeeDetailsComparer : IEqualityComparer<Employee_Details>
	{
		#region IEqualityComparer<int> Members
		public bool Equals(Employee_Details x, Employee_Details y)
		{
			//define equality
          if(x == null)
          {
            return y == null;
          }
          else if(y == null) return false;
          //now check the fields that define equality - if it's a DB record,
          //most likely an ID field
          return x.ID == y.ID; //this is just A GUESS :)
		}
		public int GetHashCode(Employee_Details obj)
		{
			//define how to get a hashcode
			//most obvious would be to define it on the IDs, 
			//but if equality is defined across multiple fields
			//then one technique is to XOR (^) multiple hash codes together
            //so either:
            return obj.ID.GetHashCode();
            //or something like
            return obj.FirstName.GetHashCode() ^ obj.Surname.GetHashCode();
		}
		#endregion
	}
