    Create Unit test class using MStest and copy the code 
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace LinqTest.Test
    {
    
        public class Employee
        {
            public int EmpId { get; set; }
            public string Name { get; set; }
            public DateTime? DOB { get; set; }
            public decimal Salary { get; set; }
            public DateTime DOJ { get; set; }
            public bool IsActive { get; set; }
        }
    
    
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
        }
    
        public class BookOrder
        {
            public int OrderId { get; set; }
            public int EmpId { get; set; }
            public int BookId { get; set; }
            public int Quantity { get; set; }
        }
        
    
    
        [TestClass]
        public class Linqtest
        {
            List<Employee> Employees;
            List<Book> Books;
            List<BookOrder> Orders;
    
            [TestInitialize]
            public void InitializeData()
            {
                Employees = new List<Employee>();
                Books = new List<Book>();
                Orders = new List<BookOrder>();
    
                Employees.Add(new Employee(){EmpId = 1, Name ="Test1" ,  DOB = new DateTime(1980,12,15),IsActive = true,Salary = 4500});
                Employees.Add(new Employee() { EmpId = 11, Name = "Test2", DOB = new DateTime(1981, 12, 15), IsActive = true, Salary = 3500 });
                Employees.Add(new Employee() { EmpId = 5, Name = "Test3", DOB = new DateTime(1970, 2, 15), IsActive = true, Salary = 5500 });
                Employees.Add(new Employee() { EmpId = 8, Name = "Test4", DOB = new DateTime(1978, 1, 15), IsActive = true, Salary = 7500 });
                Employees.Add(new Employee() { EmpId = 9, Name = "Test5", DOB = new DateTime(1972, 2, 5), IsActive = true, Salary = 2500 });
                Employees.Add(new Employee() { EmpId = 10, Name = "Test6", DOB = new DateTime(1980, 10, 8), IsActive = false, Salary = 5500 });
                Employees.Add(new Employee() { EmpId = 15, Name = "Test7", DOB = new DateTime(1983, 11, 25), IsActive = true, Salary = 3500 });
    
                Books.Add(new Book(){BookId = 2, Price = 24.99,Title = "British Food"});
                Books.Add(new Book() { BookId = 5, Price = 4.99, Title = "Holidays in UK" });
                Books.Add(new Book() { BookId = 7, Price = 7.99, Title = "UK Laws" });
    
    
                Orders.Add(new BookOrder(){EmpId = 1,OrderId = 1,BookId = 2,Quantity = 3});
                Orders.Add(new BookOrder() { EmpId = 1, OrderId = 1, BookId = 5, Quantity = 1 });
                Orders.Add(new BookOrder() { EmpId = 1, OrderId = 2, BookId = 7, Quantity = 5 });
                Orders.Add(new BookOrder() { EmpId = 11, OrderId = 3, BookId = 2, Quantity = 3 });
                Orders.Add(new BookOrder() { EmpId = 11, OrderId = 4, BookId = 7, Quantity = 3 });
            }
    
    
            [TestMethod]
            public void CheckEmpCount()
            {
    
                var res = Employees
                    .Where(e => e.EmpId > 5)
                    .Where(t =>t.Salary>=5000);
    
                Assert.AreEqual(2,res.Count());
    
                res = Employees
                    .Where(e => e.EmpId > 5);
    
                Assert.AreEqual(5,res.Count());
    
            }
    
            [TestMethod]
            public void TestGroupBy()
            {
                var res = from e in Employees
                    group e by e.Salary;
    
                Assert.AreEqual(5,res.Count());
    
                var res1 = Employees.GroupBy(e => e.Salary);
                Assert.AreEqual(5, res1.Count());
            }
    
            [TestMethod]
            public void TestJoin()
            {
                var res = from o in Orders
                    join Employee e in Employees
                        on o.EmpId equals e.EmpId
                    where o.EmpId == 11
                    select o;
    
                Assert.AreEqual(2,res.Count());
            }
    
            [TestMethod]
            public void TestJoinData()
            {
                var res = from o in Orders
                    join Employee e in Employees
                        on o.EmpId equals e.EmpId 
                    join Book b in Books
                        on o.BookId equals b.BookId 
                    orderby e.EmpId
                    select new {o.OrderId, e.Name, b.Title, b.Price};
    
                Assert.AreEqual("Test1", res.First().Name);
    
            }
            
        }
    }
