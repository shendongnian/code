    frLeczenie leczenie = new frLeczenie(this);
    public frLeczenie(Form1 formaglowna)
    {
        InitializeComponent();
        this.Formaglowna = formaglowna;
        // ...
    }
    public Form1 Formaglowna{ get; set; }
