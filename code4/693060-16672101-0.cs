    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace simpleOO
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var myEmployee = new List<Employee>();
    
                var fistEmployee = new Employee();
    
                fistEmployee.FirstName = "Filip";
                fistEmployee.LastName = "Göndek";
                fistEmployee.TechSkills.Add(new TechSkills(){Skill="Engish"});
                fistEmployee.Id=1;
                myEmployee.Add(fistEmployee);
                myEmployee.Add(new Employee()
                                               {
                                                   Id = 2,
                                                   FirstName = "Helmut",
                                                   LastName = "Müller",
                                                   TechSkills = new List<TechSkills>()
                                                                                    {
                                                                                        new TechSkills(){Skill="Engish"},
                                                                                        new TechSkills(){Skill="Spain"}
                                                                                    }
                                               }
                                               );
    
                var filteredList = myEmployee.Where(employee => employee.TechSkills.Any(skill => skill.Skill == "Spain")).ToList();
                
                var bList = new BindingList<Employee>(filteredList);
                dataGridView1.DataSource = bList;
            }
    
    
    
    
        }
    
        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            private List<TechSkills> techSkills = new List<TechSkills>();
            public List<TechSkills> TechSkills
            {
                get { return techSkills; }
                set { techSkills = value; }
            }
    
            // what ever more you need ...
        }
    
        public class TechSkills
        {
            public string Skill { get; set; }
        }
    }
