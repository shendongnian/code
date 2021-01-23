        /// <summary>
        /// Bind DropDown Lists with a cetain CSS Class
        /// </summary>
        /// <param name="control">Parent Control Containing Dropdown Lists</param>
        /// <param name="cssClass">Class that determines binding</param>
        /// <param name="tableToBind">Data Source</param>
        public void FindAndBindControlsRecursive(Control control, string cssClass, DataTable tableToBind)
        {   
            foreach (Control childControl in control.Controls)
            {
                if (childControl.GetType() == typeof(DropDownList))
                {
                    DropDownList dd = (DropDownList)childControl;
                    //Check CSS class                    
                    if (dd.CssClass.IndexOf(cssClass) > -1)
                    {
                        dd.DataSource = tableToBind;
                        //Set DataFields & TextFields
                        dd.DataBind();
                    }
                }
                else
                {
                    FindAndBindControlsRecursive(childControl, cssClass, tableToBind);
                }
            }
        }
