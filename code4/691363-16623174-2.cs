    public partial class Form1: Form
    {
        readonly ColouredSquareCollection _squares;
        readonly Random _rng = new Random();
        public Form1()
        {
            InitializeComponent();
            _squares = new ColouredSquareCollection(100, 100);
            for (int x = 0; x < _squares.Width; ++x)
                for (int y = 0; y < _squares.Height; ++y)
                    _squares[x, y] = randomColour();
            colouredSquareHolder1.Squares = _squares;
        }
        Color randomColour()
        {
            return Color.FromArgb(_rng.Next(256), _rng.Next(256), _rng.Next(256));
        }
    }
