    abstract class Employee {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract int GetBonusAmount();
    }
    class Manager : Employee {
        public override int GetBonusAmount() { return 2000; } 
    }
    class Checkout : Employee {
        public override int GetBonusAmount() { return 1000; } 
    }
    Console.WriteLine(someEmployee.GetBonusAmount());
