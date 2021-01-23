       #region childForm_Closed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void childForm_Closed(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Form2))
            {
                _form2.Dispose();
                if (_form2 != null)
                {
                    _form2 = null;
                }
            }
