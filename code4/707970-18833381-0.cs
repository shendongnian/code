        public Language language;
        private CommonLocalization commonLang;
        private ObservableCollection<string> rootCoverterTypes;
       
        public EnumLocalizationManager()
        {
            commonLang = CommonLocalization.GetInstance;
            EnumLanguage = commonLang.Lang;
        }
        //Коллекция для локализации enum RootConverterType
        public static Dictionary<Language, ObservableCollection<string>> RootConverterLocalization = new Dictionary<Language, ObservableCollection<string>>()
        {
            {
                Language.ru_RU, new ObservableCollection<string>()
                {
                    ru_RU.CameraEnumConverterTypeUndefined, ru_RU.CameraEnumConverterTypeAuto, ru_RU.CameraEnumConverterTypeNumber, ru_RU.CameraEnumConverterTypeExponent, ru_RU.CameraEnumConverterTypeDecimal, ru_RU.CameraEnumConverterTypeInteger
                }
            },
            {
                Language.en_US, new ObservableCollection<string>()
                {
                    en_US.CameraEnumConverterTypeUndefined, en_US.CameraEnumConverterTypeAuto, en_US.CameraEnumConverterTypeNumber, en_US.CameraEnumConverterTypeExponent, en_US.CameraEnumConverterTypeDecimal, en_US.CameraEnumConverterTypeInteger
                }
            }
        };
        //Коллекция для локализации enum ConverterType
        public static Dictionary<Language, ObservableCollection<string>> ConverterLocalization = new Dictionary<Language, ObservableCollection<string>>()
        {
            {
                Language.ru_RU, new ObservableCollection<string>()
                {
                    ru_RU.CameraEnumConverterTypeAuto, ru_RU.CameraEnumConverterTypeNumber, ru_RU.CameraEnumConverterTypeExponent, ru_RU.CameraEnumConverterTypeDecimal, ru_RU.CameraEnumConverterTypeInteger
                }
            },
            {
                Language.en_US, new ObservableCollection<string>()
                {
                    en_US.CameraEnumConverterTypeAuto, en_US.CameraEnumConverterTypeNumber, en_US.CameraEnumConverterTypeExponent, en_US.CameraEnumConverterTypeDecimal, en_US.CameraEnumConverterTypeInteger
                }
            }
        };
        
        
        public ObservableCollection<string> RootConverterTypes
        {
            get { return rootCoverterTypes; }
        }
        public ObservableCollection<string> ConverterTypes
        {
            get { return coverterTypes; }
        }
        
        public Language EnumLanguage
        {
            get { return language; }
            set
            {
                language = value;
                ChangeEnumLanguage();
                
            }
        }
        private void ChangeEnumLanguage()
        {
            if (RootConverterLocalization.ContainsKey(language))
            {
                rootCoverterTypes = RootConverterLocalization[language];
            }
            if (ConverterLocalization.ContainsKey(language))
            {
                coverterTypes = ConverterLocalization[language];
            }
            RaisePropertyChanged();
            RaisePropertyChangedByName("RootConverterTypes");
            RaisePropertyChangedByName("ConverterTypes");
	   }
    }
