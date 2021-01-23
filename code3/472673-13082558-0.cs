    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
    
        public List<DataStructure> DataList { get; set; }
    
        public MainPage()
        {
            this.InitializeComponent();
            DataList = Enumerable.Range(0, 25).Select(i => new DataStructure() { Id = i, Data = string.Format("Number : {0}", i) }).ToList();
            this.Loaded += MainPage_Loaded;
        }
    
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= MainPage_Loaded;
            //var xmlDocument =
            //    new XDocument(
            //        new XElement("DataList",
            //            DataList.Select(dataItem =>
            //                new XElement("DataItem",
            //                    new XAttribute("id", dataItem.Id), new XAttribute("data", dataItem.Data)))));
    
            var rootNode = new XElement("DataList");
            var xmlDocument = new XDocument(rootNode);
            foreach (var dataItem in DataList)
            {
                rootNode.Add(new XElement("DataItem",
                                new XAttribute("id", dataItem.Id), new XAttribute("data", dataItem.Data)));
            }
    
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("XML Document", new List<string>() { ".xml" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Xml Document";
    
            StorageFile file = await savePicker.PickSaveFileAsync();
            // Process picked file
            if (file != null)
            {
                // Store file for future access
                var fileToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                var writterStream = await file.OpenStreamForWriteAsync();
                xmlDocument.Save(writterStream);
            }
    
        }
