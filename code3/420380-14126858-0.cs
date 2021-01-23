        /// <summary>
        /// Occurs when a control for editing a cell is showing
        /// </summary>
        /// <remarks>Capture key press to handle key entry in datagridview</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDCAL_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgDCAL.EditingControl.KeyPress -= EditingControl_KeyPress;
            dgDCAL.EditingControl.KeyPress += EditingControl_KeyPress;
        }
        /// <summary>
        /// Handle datagridview cell keypress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow 0-9, backspace, period and return key
            if (!Char.IsNumber(e.KeyChar) && 
                (int)e.KeyChar != 8 &&
                (int)e.KeyChar != 46 &&
                (int)e.KeyChar != 13) e.Handled = true;
        }
