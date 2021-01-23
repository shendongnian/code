    [Serializable, ClassInterface(ClassInterfaceType.AutoDual)]
    class helperDomain<T>: MarshalByRefObject where T: class
    {
        #region private
        private AppDomain _app_domain;
        private AppDomainSetup _app_domain_info;
        private string _assembly_class_name;
        private string _assembly_file;
        private string _assembly_file_name;
        private T _inner_class;
        private bool _load_ok;
        private string _loading_errors;
        private string _path;
        #endregion
        #region .ctor
        public helperDomain(string AssemblyFile, 
           string configFile = null, string domainName)
        {
            this._load_ok = false;
            try
            {
                this._assembly_file = AssemblyFile; //full path to assembly
                this._assembly_file_name = System.IO.Path.GetFileName(this._assembly_file); //assmbly file name
                this._path = System.IO.Path.GetDirectoryName(this._assembly_file); //get root directory from assembly path 
                this._assembly_class_name = typeof(T).ToString(); //the class name to instantiate in the domain from the assembly
                //start to configure domain
                this._app_domain_info = new AppDomainSetup();
                this._app_domain_info.ApplicationBase = this._path;
                this._app_domain_info.PrivateBinPath = this._path;
                this._app_domain_info.PrivateBinPathProbe = this._path;
                if (!string.IsNullOrEmpty(configFile))
                {
                    this._app_domain_info.ConfigurationFile = configFile;
                }
                //lets create the domain
                this._app_domain = AppDomain.CreateDomain(domainName, null, this._app_domain_info);
                //instantiate the class
                this._inner_class = (T) this._app_domain.CreateInstanceFromAndUnwrap(this._assembly_file, this._assembly_class_name);
                this._load_ok = true;
            }
            catch (Exception exception)
            {
                //There was a problema setting up the new appDomain
                this._load_ok = false;
                this._loading_errors = exception.ToString();
            }
        }
        #endregion
        #region public properties
        public string AssemblyFile
        {
            get
            {
                return _assembly_file;
            }
        }
        public string AssemblyFileName
        {
            get
            {
                return _assembly_file_name;
            }
        }
        public AppDomain AtomicAppDomain
        {
            get
            {
                return _app_domain;
            }
        }
        public T InstancedObject
        {
            get
            {
                return _inner_class;
            }
        }
        public string LoadingErrors
        {
            get
            {
                return _loading_errors;
            }
        }
        public bool LoadOK
        {
            get
            {
                return _load_ok;
            }
        }
        public string Path
        {
            get
            {
                return _path;
            }
        }
        #endregion
    }
