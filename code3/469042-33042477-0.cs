    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace DXApplication1
    {
        public partial class MyWaitForm : DevExpress.XtraWaitForm.WaitForm
        {
            public MyWaitForm()
            {
                InitializeComponent();
            }
            public override void SetDescription(string description)
            {
                base.SetDescription(description);
                lbDescription.Text = description;
            }
            public override void SetCaption(string caption)
            {
                base.SetCaption(caption);
                lbCaption.Text = caption;
            }
        }
    }
