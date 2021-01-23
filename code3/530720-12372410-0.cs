        public void ShowDialog<TParentForm, TDialogForm, TModel, TEntity>(TParentForm t, TDialogForm m, Action callback)
            where TParentForm : UserControl
            where TModel : class, IModel<TEntity>, new()
            where TDialogForm : Form, IEditableItem<TEntity>, new()
        {
            using (var dialogToShow = new TDialogForm())
            {
                dialogToShow.StartPosition = FormStartPosition.CenterScreen;
                dialogToShow.FormBorderStyle = FormBorderStyle.FixedSingle;
                dialogToShow.Model = new TModel();
                // 2. show the new user control/form to the user.
                var result = dialogToShow.ShowDialog(t);
                // 3. handle the dialog result returned and update the UI appropriately.
                if (result == DialogResult.OK)
                {
                    // print status label.
                    callback.Invoke();
                }
            }
        }
