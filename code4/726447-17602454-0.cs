     public MainWindow()
        {
            InitializeComponent();
            messages.Add(new Message(DateTime.Now, "This is a test."));
            messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
            messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
            messages.Add(new Message(DateTime.Now, "This is a multi-line message.\nThis is a multi-line message."));
            messages.Add(new Message(DateTime.Now, "This is a test."));
            messages.Add(new Message(DateTime.Now, "This is a test."));
            messages.Add(new Message(DateTime.Now, "This is a test."));
            messages.Add(new Message(DateTime.Now, "This is a test."));
            ListView listView = new ListView();
            CreateListViewItemStyle(listView);
            GridView gridView = new GridView();
            listView.View = gridView;
            GridViewColumn timeStampColumn = new GridViewColumn();
            timeStampColumn.DisplayMemberBinding = new Binding("Date");
            GridViewColumnHeader timeStampHeader = new GridViewColumnHeader();
            timeStampHeader.Content = "Time";
            timeStampColumn.Header = timeStampHeader;
            gridView.Columns.Add(timeStampColumn);
            GridViewColumn messageColumn = CreateGridViewColumn("Message", "Text");
            gridView.Columns.Add(messageColumn);
            Binding binding = new Binding();
            binding.Source = messages;
            listView.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            MainGrid.Children.Add(listView);
        }
        private static void CreateListViewItemStyle(ListView listView)
        {
            string xaml = @"
            <Style  xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" TargetType=""ListViewItem"">
                <Setter Property=""Height"" Value=""20""/>
                <Setter Property=""Template"">
                    <Setter.Value>
                    <ControlTemplate TargetType=""{x:Type ListViewItem}"">
                        <Border Background=""{TemplateBinding Background}""
                                CornerRadius=""0"">
                            <GridViewRowPresenter/>
                        </Border>
                    </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding=""{Binding Text}"" Value=""This is a test."">
                        <Setter Property=""Background"" Value=""Pink""/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>";
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            listView.ItemContainerStyle = XamlReader.Load(xmlReader) as Style;
        }
