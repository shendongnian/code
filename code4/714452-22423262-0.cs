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
     public partial class MyForm : Form
      {
        //Public Declaration:
        double rW = 0;
        double rH = 0;
        int fH = 0;
        int fW = 0;
        // @ Form Initialization
        public MyForm()
        {
            InitializeComponent();
            this.Resize += MyForm_Resize; // handles resize routine
            this.tabControl1.Dock = DockStyle.None;
           
        }
       
        private void MyForm_Resize(object sender, EventArgs e)
        {
            rResize(this,true); //Call the routine
           
        }
        
        private void rResize(Control t, bool hasTabs) // Routine to Auto resize the control
        {
              
            // this will return to normal default size when 1 of the conditions is met
            
            string[] s = null;
            if (this.Width < fW || this.Height < fH)
            {
                
                this.Width = (int)fW;
                this.Height = (int)fH;
               
                return;
            }
            foreach (Control c in t.Controls)
            {
                // Option 1:
                double rRW = (t.Width > rW ? t.Width / (rW) : rW / t.Width);
                double rRH = (t.Height > rH ? t.Height / (rH) : rH / t.Height);
               
                // Option 2:
                //  double rRW = t.Width / rW;
                //  double rRH = t.Height / rH;
              
                s = c.Tag.ToString().Split('/');
                if (c.Name == s[0].ToString())
                {
                    //Use integer casting
                    c.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                    c.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                    c.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                    c.Top = (int)(Convert.ToInt32(s[2]) * rRH);
                }
                if (hasTabs)
                {
                    if (c.GetType() == typeof(TabControl))
                    {
                        foreach (Control f in c.Controls)
                        {
                            foreach (Control j in f.Controls) //tabpage
                            {
                                s = j.Tag.ToString().Split('/');
                                if (j.Name == s[0].ToString())
                                {
                                    j.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                                    j.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                                    j.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                                    j.Top = (int)(Convert.ToInt32(s[2]) * rRH);
                                }
                            }
                        }
                    }
                }
            }
        }
        // @ Form Load Event
        private void MyForm_Load(object sender, EventArgs e)
        {
            
            // Put values in the variables
            
            rW = this.Width;
            rH = this.Height;
            fW = this.Width;
            fH = this.Height;
          
            // Loop through the controls inside the  form i.e. Tabcontrol Container
            foreach (Control c in this.Controls)
            {
                c.Tag = c.Name + "/" + c.Left + "/" + c.Top + "/" + c.Width + "/" + c.Height;
                               
                // c.Anchor = (AnchorStyles.Right |  AnchorStyles.Left ); 
                if (c.GetType() == typeof(TabControl))
                {
                    foreach (Control f in c.Controls)
                    {
                        
                        foreach (Control j in f.Controls) //tabpage
                        {
                            j.Tag = j.Name + "/" + j.Left + "/" + j.Top + "/" + j.Width + "/" + j.Height;
                        }
                    }
                }
            }
        }
    }
    }
