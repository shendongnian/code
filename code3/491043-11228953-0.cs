    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using Telerik.Web.UI;
    namespace #######################################
    {
        public class RequiredFieldValidatorForImages :
                            System.Web.UI.WebControls.BaseValidator
        {
            private Control _ctrl;
            public RequiredFieldValidatorForImages()
            {
                base.EnableClientScript = false;
            }
            protected override bool ControlPropertiesValid()
            {
                Control ctrl = FindControl(ControlToValidate);
                if (ctrl != null)
                {
                    _ctrl = (Control)ctrl;
                    return (_ctrl != null);
                }
                else
                    return false;  // raise exception
            }
            protected override bool EvaluateIsValid()
            {
                try
                {
                    Image rbi = (Image)_ctrl;
                    return rbi.ImageUrl != "~/images/noimages.jpg";
                }
                catch
                {
                    RadBinaryImage rbi = (RadBinaryImage)_ctrl;
                    return rbi.ImageUrl != "~/images/noimages.jpg";
                }
            }
        }
    }
