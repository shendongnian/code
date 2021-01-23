    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class BaseControl : UserControl
        {
            public BaseControl()
            {
                InitializeComponent();
            }
            [DefaultValue(false)]
            public bool IsTitlePanelVisible
            {
                get { return panTitle.Visible; }
                set { panTitle.Visible = value; }
            } 
        }
    }
