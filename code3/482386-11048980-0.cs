    public interface IDialogService
    {
        /// <summary>
        /// Displays the specified dialog.
        /// </summary>
        /// <remarks>This method is non-blocking. If you need to access the return value of the dialog, you can either
        /// provide a callback method or subscribe to the <see cref="T:System.IObservable{bool?}" /> that is returned.</remarks>
        /// <param name="dialog">The dialog to display.</param>
        /// <param name="callback">The callback to be called when the dialog closes.</param>
        /// <returns>An <see cref="T:System.IObservable{bool?}" /> that broadcasts the value returned by the dialog
        /// to any observers.</returns>
        IObservable<bool?> Show(Dialog dialog, Action<bool?> callback = null);
        /// <summary>
        /// Displays the specified dialog. This method waits for the dialog to close before it returns.
        /// </summary>
        /// <remarks>This method waits for the dialog to close before it returns. If you need to show a dialog and
        /// return immediately, use <see cref="M:Show"/>.</remarks>
        /// <param name="dialog">The dialog to display.</param>
        /// <returns>The value returned by the dialog.</returns>
        bool? ShowDialog(Dialog dialog);
    }
