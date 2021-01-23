    public class Exercicio
    {
        public string Nome { get; set; }
        public Objective Objective { get; set; }
        public Exercicio(string nome, Objective objective)
        {
            this.Nome = nome;
            this.Objective = objective;
        }
    }
    public class Objective
    {
        public string Descricao { get; set; }
        public Objective(string d)
        {
            this.Descricao = d;
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        var items = new ObservableCollection<Exercicio>(new[] {
            new Exercicio("Exercicio1", new Objective("Objective1")),
            new Exercicio("Exercicio2", new Objective("Objective2")),
            new Exercicio("Exercicio3", new Objective("Objective3"))
        });
        dgExercicios.ItemsSource = items;
    }
