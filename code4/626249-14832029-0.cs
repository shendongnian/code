    private Form2 _form2;
    #region UtilOpenForm
        /// <summary>
        /// UtilOpenForm
        /// </summary>
        /// <param name="appContainer"></param>
        /// <param name="childForm"></param>
        private void UtilOpenForm(Form appContainer, Form childForm)
        {
            this.Cursor = Cursors.WaitCursor;
            if (childForm == null)
            {
                throw new ArgumentNullException("childForm");
            }
            childForm.MdiParent = appContainer;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.MaximizeBox = false;
            childForm.MinimizeBox = false;
            childForm.Closed += new EventHandler(childForm_Closed);
            childForm.Show();
            this.Cursor = Cursors.Default;
        }
