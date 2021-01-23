    public sealed class Application: MarshalByRefObject {
        private readonly dynamic _application;
        // Methods
        public Application() {
            const string progId = "Broker.Application";
            _application = Activator.CreateInstance(Type.GetTypeFromProgID(progId));
        }
        public Application(dynamic application) {
            _application = application;
        }
        public int Import(ImportType type, string path) {
            return _application.Import((short) type, path);
        }
        public int Import(ImportType type, string path, string defFileName) {
            return _application.Import((short) type, path, defFileName);
        }
        public bool LoadDatabase(string path) {
            return _application.LoadDatabase(path);
        }
        public bool LoadLayout(string path) {
            return _application.LoadLayout(path);
        }
        public int Log(ImportLog action) {
            return _application.Log((short) action);
        }
        public void Quit() {
            _application.Quit();
        }
        public void RefreshAll() {
            _application.RefreshAll();
        }
        public void SaveDatabase() {
            _application.SaveDatabase();
        }
        public bool SaveLayout(string path) {
            return _application.SaveLayout(path);
        }
        // Properties
        public Document ActiveDocument {
            get {
                var document = _application.ActiveDocument;
                return document != null ? new Document(document) : null;
            }
        }
        public Window ActiveWindow {
            get {
                var window = _application.ActiveWindow;
                return window != null ? new Window(window) : null;
            }
        }
        public AnalysisDocs AnalysisDocs {
            get {
                var analysisDocs = _application.AnalysisDocs;
                return analysisDocs != null ? new AnalysisDocs(analysisDocs) : null;
            }
        }
        public Commentary Commentary {
            get {
                var commentary = _application.Commentary;
                return commentary != null ? new Commentary(commentary) : null;
            }
        }
        public Documents Documents {
            get {
                var documents = _application.Documents;
                return documents != null ? new Documents(documents) : null;
            }
        }
        public string DatabasePath {
            get { return _application.DatabasePath; }
        }
        public bool Visible {
            get { return _application.Visible != 0; }
            set { _application.Visible = value ? 1 : 0; }
        }
        public string Version {
            get { return _application.Version; }
        }
    }
