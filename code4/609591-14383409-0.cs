    namespace WebCrawler.SantaCatarina
    {
    class SCLinkFinder : ILinkFinder
    {
        private readonly Queue<char> _alfabeto;
        private int _paginaAtual;
        private char _letraAtual;
        public SCLinkFinder()
        {
            _alfabeto = new Queue<char>();
            _alfabeto.Enqueue('1');
            _alfabeto.Enqueue('A');
            _alfabeto.Enqueue('B');
            _alfabeto.Enqueue('C');
            _alfabeto.Enqueue('D');
            _alfabeto.Enqueue('E');
            _alfabeto.Enqueue('F');
            _alfabeto.Enqueue('G');
            _alfabeto.Enqueue('H');
            _alfabeto.Enqueue('I');
            _alfabeto.Enqueue('J');
            _alfabeto.Enqueue('K');
            _alfabeto.Enqueue('L');
            _alfabeto.Enqueue('M');
            _alfabeto.Enqueue('N');
            _alfabeto.Enqueue('O');
            _alfabeto.Enqueue('P');
            _alfabeto.Enqueue('Q');
            _alfabeto.Enqueue('R');
            _alfabeto.Enqueue('S');
            _alfabeto.Enqueue('T');
            _alfabeto.Enqueue('U');
            _alfabeto.Enqueue('V');
            _alfabeto.Enqueue('W');
            _alfabeto.Enqueue('X');
            _alfabeto.Enqueue('Y');
            _alfabeto.Enqueue('Z');
            _paginaAtual = 1;
            _letraAtual = _alfabeto.Dequeue();
        }
        public string[] Find(string url)
        {
            List<string> _empresas = new List<string>();
            if (!_alfabeto.Any() && _letraAtual == ' ')
            {
                return _empresas.ToArray();
            }
            var webGet = new HtmlWeb();
            var formattedUrl = String.Format(url, _letraAtual, _paginaAtual++);
            var document = webGet.Load(formattedUrl);
            var nodes = document.DocumentNode.SelectNodes("//div[@id='conteudo']/div[@class='gratuito']/p/a");
            foreach (var node in nodes)
            {
                var href = node.GetAttributeValue("href", "");
                _empresas.Add(href);
            }
            var elUrlProximaPagina = document.DocumentNode.SelectSingleNode("//div[@id='principal']/div[@id='conteudo']/div[@class='paginacao']/a[contains(@class,'nextPage')]");
            if (elUrlProximaPagina == null)
            {
                _letraAtual = _alfabeto.Any() ? _alfabeto.Dequeue() : ' ';
                _paginaAtual = 1;
            }
            Console.WriteLine(_letraAtual);
            Console.WriteLine(_paginaAtual);
            //Your code to read _empresas and Persist in database(or file)            
            return Find(url);
        }
    }
}
