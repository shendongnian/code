    public string ConvertExpression(string expression)
    {
        _matches = Regex.Matches(expression, @"\d+|\(|\)|[a-zA-Z]+")
            .Cast<Match>()
            .GetEnumerator();
        _error = false;
        return GetToken() ? Expression() : "";
    }
    private bool GetToken()
    {
        _number = 0;
        _tokenType = TokenType.None;
        _text = null;
        if (_error || !_matches.MoveNext())
            return false;
        _text = _matches.Current.Value;
        switch (_text[0]) {
            case '(':
                _tokenType = TokenType.LPar;
                break;
            case ')':
                _tokenType = TokenType.RPar;
                break;
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                _tokenType = TokenType.Number;
                _number = Int32.Parse(_text);
                break;
            default:
                _tokenType = TokenType.Text;
                break;
        }
        return true;
    }
