    using System;
    using System.Linq;
    using System.Windows.Forms;
    public class Student
    {
        public int Age { get; set; }
        public double GPA { get; set; }
        public string Name { get; set; }
    }
    
    internal class Program
    {
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            using(var grid = new DataGridView { Dock = DockStyle.Fill})
            using(var form = new Form { Controls = {grid}}) {
                // typed
                var arrStudents = new[] {
                    new Student{ Age = 1, GPA = 2, Name = "abc"},
                    new Student{ Age = 3, GPA = 4, Name = "def"},
                    new Student{ Age = 5, GPA = 6, Name = "ghi"},
                };
                form.Text = "Typed Array";
                grid.DataSource = arrStudents;
                form.ShowDialog();
    
                // anon-type
                var anonTypeArr = arrStudents.Select(
                    x => new {x.Age, x.GPA, x.Name}).ToArray();
                grid.DataSource = anonTypeArr;
                form.Text = "Anonymous Type Array";
                form.ShowDialog();
            }
        }
    }
