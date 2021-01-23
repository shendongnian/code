        /// <summary>
        /// Find TextBoxes Recursively in the User control's control collection
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private void FindControlRecursiveByType(ControlCollection controls, ref List<TextBox> OutputList)
        {
            foreach (WebControl control in controls.OfType<WebControl>())
            {
                if (control is TextBox)
                    OutputList.Add(control as TextBox);
                if (control.Controls.Count > 0)
                    FindControlRecursiveByType(control.Controls, ref OutputList);
            }
        }
