    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private class Kid
            {
                public bool Gender { get; set; }
                public String Name { get; set; }
            }
    
            private List<Kid> kids;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // === Load data =================================================
                kids = new List<Kid>();
                kids.Add(new Kid { Name = "John", Gender = true });
                kids.Add(new Kid { Name = "Paul", Gender = true });
                kids.Add(new Kid { Name = "Jack", Gender = true });
                kids.Add(new Kid { Name = "Brenda", Gender = false });
                kids.Add(new Kid { Name = "Judith", Gender = false });
                kids.Add(new Kid { Name = "Sofia", Gender = false });
    
                Kid foundKid = foundAMatch("sofIa");
            }
    
            private Kid foundAMatch(string name)
            {
                var result = (from K in kids
                              where K.Name.ToLower() == name.ToLower() 
                              select K);
    
                if (result.Count() != 0)
                    return result.First();
                else
                    return null;
            }
    
            private Kid foundAMatch(string name, bool gender)
            {
                var result = (from K in kids
                              where K.Name.ToLower() == name.ToLower() && K.Gender == gender
                              select K);
    
                if (result.Count() != 0)
                    return result.First();
                else
                    return null;
            }
    
        }
    }
