    public class ViewModelProperties
    {
        private ObservableCollection<ServerProperties> properties = new ObservableCollection<ServerProperties>();
        public ObservableCollection<ServerProperties> Properties
        {
            get
            {
                return properties;
            }
        }
        public void SetProperties()
        {
            properties.Clear();
            for (var lineNumber = 0; lineNumber < MainWindow.lineCount; lineNumber++)
            {
                if (MainWindow.textProperties[lineNumber, 0] == null) break;
                properties.Add(new ServerProperties(MainWindow.textProperties[lineNumber, 0],
                                                    MainWindow.textProperties[lineNumber, 1]));
            }
        }
    }
