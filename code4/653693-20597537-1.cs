            protected PrintDocument printDocument = null;
            protected IPrintDocumentSource printDocumentSource = null;
            internal List<UIElement> printPreviewElements = new List<UIElement>();
            protected event EventHandler pagesCreated;
    
            protected void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
            {
                PrintTask printTask = null;
                printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", sourceRequested =>
                {
                    printTask.Completed += async (s, args) =>
                    {
                        if (args.Completion == PrintTaskCompletion.Failed)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                            {
                                MessageDialog dialog = new MessageDialog("Something went wrong while trying to print. Please try again.");
                                await dialog.ShowAsync();
                            });
                        }
                    };
                    sourceRequested.SetSource(printDocumentSource);
                });
            }
    
            protected void RegisterForPrinting()
            {
                printDocument = new PrintDocument();
                printDocumentSource = printDocument.DocumentSource;
                printDocument.Paginate += CreatePrintPreviewPages;
                printDocument.GetPreviewPage += GetPrintPreviewPage;
                printDocument.AddPages += AddPrintPages;
                PrintManager printMan = PrintManager.GetForCurrentView();
                printMan.PrintTaskRequested += PrintTaskRequested;
            }
    
            protected void UnregisterForPrinting()
            {
                if (printDocument != null)
                {
                    printDocument.Paginate -= CreatePrintPreviewPages;
                    printDocument.GetPreviewPage -= GetPrintPreviewPage;
                    printDocument.AddPages -= AddPrintPages;
                    PrintManager printMan = PrintManager.GetForCurrentView();
                    printMan.PrintTaskRequested -= PrintTaskRequested;
                }
            }
    
            protected void CreatePrintPreviewPages(object sender, PaginateEventArgs e)
            {
                printPreviewElements.Clear();
                PrintTaskOptions printingOptions = ((PrintTaskOptions)e.PrintTaskOptions);
                PrintPageDescription pageDescription = printingOptions.GetPageDescription(0);
                AddOnePrintPreviewPage(pageDescription);
                if (pagesCreated != null)
                {
                    pagesCreated.Invoke(printPreviewElements, null);
                }
                ((PrintDocument)sender).SetPreviewPageCount(printPreviewElements.Count, PreviewPageCountType.Intermediate);
            }
    
            protected void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
            {
                ((PrintDocument)sender).SetPreviewPage(e.PageNumber, printPreviewElements[e.PageNumber - 1]);
            }
    
            protected void AddPrintPages(object sender, AddPagesEventArgs e)
            {
                foreach (UIElement element in printPreviewElements)
                {
                    printDocument.AddPage(element);
                }
                ((PrintDocument)sender).AddPagesComplete();
            }
    
            protected void AddOnePrintPreviewPage(PrintPageDescription printPageDescription)
            {
                TextBlock block = new TextBlock();
                block.Text = "This is an example.";
                block.Width = printPageDescription.PageSize.Width;
                block.Height = printPageDescription.PageSize.Height;
                printPreviewElements.Add(block);
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                RegisterForPrinting();
            }
    
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                UnregisterForPrinting();
            }
