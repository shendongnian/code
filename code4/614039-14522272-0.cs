    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Crom.Controls.Docking;
    
    namespace DockingTester
    {
        public partial class Form1 : Form
        {
            private Form dummyForm;
            private readonly Guid dummyFormGuid = Guid.NewGuid();
    
    
            public Form1()
            {
                InitializeComponent();
                CreateDummyForm();
                this.dummyForm.Show();
            }
    
            private void CreateDummyForm()
            {
                dummyForm = new Form();
                this.dummyForm.Text = "Dummy docking test form";
            }
    
            private static void DockUndockForm(DockContainer dockContainer, Form form, Guid guid)
            {
                DockableFormInfo formInfo = dockContainer.GetFormInfo(guid);
    
                //Add
                if (formInfo == null)
                {
                    formInfo = dockContainer.Add(form, zAllowedDock.All, guid);
                    dockContainer.DockForm(formInfo, DockStyle.Left, zDockMode.Inner);
                }
                //Remove
                else
                {
                    Form dummy =  formInfo.DockableForm;
                    dockContainer.Undock(formInfo, new Rectangle(Point.Empty, new Size(100, 300)));
                    dockContainer.Remove(formInfo);
    
                    dummy.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    dummy.TopLevel = true;
                }
            }
    
            private void dockUndockButton_Click(object sender, EventArgs e)
            {
                if (this.dummyForm.IsDisposed)
                    CreateDummyForm();
                DockUndockForm(this.dockContainer1, this.dummyForm, this.dummyFormGuid);
            }
    
        }
    }
