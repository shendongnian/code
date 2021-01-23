    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public int rglu;
            public DateTime rdate;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnShowForm2_Click(object sender, EventArgs e)
            {
                Form2 frm2=new Form2();
                frm2.Form1Instance = this;
                frm2.Show();
            }
            public void sort()
            {
                datelist = new List<DateTime>(rdate);
                datelist.Sort((a, b) => a.CompareTo(b));
    
                var result = rdate
                .Select((d, i) => new { Date = d, Int = rglu[i] })
                .OrderBy(o => o.Date) // Sort by whatever field you want
                .ToArray();
    
                this.rdate = result.Select(o => o.Date).ToArray();
                this.rglu = result.Select(o => o.Int).ToArray();  //all works fine
    
                for (int i = 7; i + 7 <= rglu.Length; i++)
                {
                    Console.WriteLine(Convert.ToString(rdate[i]) + Convert.ToString(rglu[i]));
                } //This returns values as expected
            }
        }
    }
