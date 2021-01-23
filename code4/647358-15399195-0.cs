    public class CustomDocumentViewer : DocumentViewer
    {
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(Image), typeof(CustomDocumentViewer), new UIPropertyMetadata(null));
        public Image BackgroundImage
        {
            get { return GetValue(BackgroundImageProperty) as Image; }
            set { SetValue(BackgroundImageProperty, value); }
        }
        protected override void OnDocumentChanged()
        {
            (Document as FixedDocument).Pages[0].Child.Children.Insert(0, BackgroundImage);
            base.OnDocumentChanged();
        }
        protected override void OnPrintCommand()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                (Document as FixedDocument).Pages[0].Child.Children.RemoveAt(0);
                printDialog.PrintDocument(Document.DocumentPaginator, "Test page");
                (Document as FixedDocument).Pages[0].Child.Children.Insert(0, BackgroundImage);
            }
        }
    }
    ...
    <local:CustomDocumentViewer x:Name="viewer" BackgroundImage="{StaticResource PaperFormImage}"/>
    ...
    InitializeComponent();
    viewer.Document = Application.LoadComponent(new Uri("/PaperFormDocument.xaml", UriKind.Relative)) as IDocumentPaginatorSource;
