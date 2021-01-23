    private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            
    fd.DocumentPaginator.PageSize = new Size(pd.PrintableAreaWidth,fd.PrintableAreaHeight);
            for (int i = 0; i <= 5; i++)
            {
                FixedPage page1 = new FixedPage();
                page1.Width = fd.DocumentPaginator.PageSize.Width;
                page1.Height = fd.DocumentPaginator.PageSize.Height;
                UIElement page1Text = pages();
                page1.Children.Add(page1Text);
                PageContent page1Content = new PageContent();
                ((IAddChild)page1Content).AddChild(page1);
                fd.Pages.Add(page1Content);
            }
            
            DocumentViewer dr = new DocumentViewer();
            dr.Height = 700;
            dr.Document =fd;
            stack.Children.Add(dr);
        }
        private UIElement pages()
        {
            Canvas pcan = new Canvas();
            
            TextBlock page1Text = new TextBlock();
            page1Text.Text = "This is a test";
            page1Text.FontSize = 40;
            page1Text.Margin = new Thickness(96);
            pcan.Children.Add(page1Text);
            return pcan;
        }
