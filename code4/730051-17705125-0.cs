    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace EmpID_071713
    {
        class Employee
        {
            private string employeeName, department;
            private int basicSalary, hra, da, ta, grossSalary;
            private double netSalary;
        public void ReadData()
        {
            Console.WriteLine("Enter the Employee name : ");
            employeeName = Console.ReadLine();
            Console.WriteLine("Enter the Depatrment name : ");
            department = Console.ReadLine();
            Console.WriteLine("Enter the Basic Salary : ");
            basicSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the HRA : ");
            hra = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the DA : ");
            da = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the TA : ");
            ta = Convert.ToInt32(Console.ReadLine());
            grossSalary = (basicSalary + hra + da + ta);
            netSalary = grossSalary - (grossSalary * 0.22);
        }
        class Program
        {
            static void Main(string[] args)
            {
                Employee objEmp = new Employee();               
                objEmp.ReadData();
                Console.WriteLine("The Gross Salary is : " + objEmp.grossSalary);
                Console.WriteLine("The basic Salary is : " + objEmp.netSalary);
                Console.ReadLine();
            }
        }
    }
