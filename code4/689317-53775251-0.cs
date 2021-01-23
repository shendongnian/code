    public MyWPFWindow()
        {
            InitializeComponent();        
            /// <summary>
            /// Change ShortDate on Culture for this <see cref="MyWPFWindow"/>
            /// </summary>
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            cd.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
        }
