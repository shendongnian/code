        /// <summary>
        /// This is the event handler for PrintManager.PrintTaskRequested.
        /// </summary>
        /// <param name="sender">PrintManager</param>
        /// <param name="e">PrintTaskRequestedEventArgs </param>
        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
        {
            PrintTask printTask = e.Request
                                   .CreatePrintTask("Pass", PrintSourceTaskHandler);
            printTask.Options.Orientation = PrintOrientation.Landscape;
        }
