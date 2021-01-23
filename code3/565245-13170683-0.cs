internal class SqlInjectionValidator
{
	internal static readonly List<string> _s_keywords = new List<string>
	{
		"alter",
		"begin",
		"commit",
		"create",
		"delete",
		"drop",
		"exec",
		"execute",
		"grant",
		"insert",
		"kill",
		"load",
		"revoke",
		"rollback",
		"shutdown",
		"truncate",
		"update",
		"use",
		"sysobjects"
	};
	private string _sql;
	private int _pos;
	private readonly Stack<char> _literalQuotes = new Stack<char>();
	private readonly Stack<char> _identifierQuotes = new Stack<char>();
	private int _statementCount;
	// Returns true if s does not contain SQL keywords.
	public SqlValidationStatus Validate(string s)
	{
		if (String.IsNullOrEmpty(s))
		{
			return SqlValidationStatus.Ok;
		}
		_pos = 0;
		_sql = s.ToLower();
		_literalQuotes.Clear();
		_identifierQuotes.Clear();
		_statementCount = 0;
		List<char> chars = new List<char>();
		SqlValidationStatus svs;
		while (_pos < _sql.Length)
		{
			if (_pos >= _sql.Length)
			{
				break;
			}
			if (_statementCount != 0)
			{
				return SqlValidationStatus.SqlBatchNotAllowed;
			}
			char c = _sql[_pos];
			if (IsEmbeddedQuote(c))
			{
				_pos++;
				chars.Add(_sql[_pos]);
				_pos++;
				continue;
			}
			if (c != '\'' &&
					IsQuotedString())
			{
				chars.Add(c);
				_pos++;
				continue;
			}
			if (c != ']' &&
					c != '[' &&
					c != '"' &&
					IsQuotedIdentifier())
			{
				chars.Add(c);
				_pos++;
				continue;
			}
			switch (c)
			{
				case '[':
					if (_identifierQuotes.Count != 0)
					{
						return SqlValidationStatus.MismatchedIdentifierQuote;
					}
					svs = DisallowWord(chars);
					if (svs != SqlValidationStatus.Ok)
					{
						return svs;
					}
					_identifierQuotes.Push(c);
					break;
				case ']':
					if (_identifierQuotes.Count != 1 ||
							_identifierQuotes.Peek() != '[')
					{
						return SqlValidationStatus.MismatchedIdentifierQuote;
					}
					svs = DisallowWord(chars);
					if (svs != SqlValidationStatus.Ok)
					{
						return svs;
					}
					_identifierQuotes.Pop();
					break;
				case '"':
					if (_identifierQuotes.Count == 0)
					{
						svs = DisallowWord(chars);
						if (svs != SqlValidationStatus.Ok)
						{
							return svs;
						}
						_identifierQuotes.Push(c);
					}
					else if (_identifierQuotes.Count == 1)
					{
						svs = DisallowWord(chars);
						if (svs != SqlValidationStatus.Ok)
						{
							return svs;
						}
						_identifierQuotes.Pop();
					}
					else
					{
						return SqlValidationStatus.MismatchedIdentifierQuote;
					}
					break;
				case '\'':
					if (_literalQuotes.Count == 0)
					{
						svs = DisallowWord(chars);
						if (svs != SqlValidationStatus.Ok)
						{
							return svs;
						}
						_literalQuotes.Push(c);
					}
					else if (_literalQuotes.Count == 1 &&
							_literalQuotes.Peek() == c)
					{
						_literalQuotes.Pop();
						chars.Clear();
					}
					else
					{
						return SqlValidationStatus.MismatchedLiteralQuote;
					}
					break;
				default:
					if (Char.IsLetterOrDigit(c) ||
							c == '-')
					{
						chars.Add(c);
					}
					else if (Char.IsWhiteSpace(c) ||
							Char.IsControl(c) ||
							Char.IsPunctuation(c))
					{
						svs = DisallowWord(chars);
						if (svs != SqlValidationStatus.Ok)
						{
							return svs;
						}
						if (c == ';')
						{
							_statementCount++;
						}
					}
					break;
			}
			_pos++;
		}
		if (_literalQuotes.Count != 0)
		{
			return SqlValidationStatus.MismatchedLiteralQuote;
		}
		if (_identifierQuotes.Count != 0)
		{
			return SqlValidationStatus.MismatchedIdentifierQuote;
		}
		if (chars.Count > 0)
		{
			svs = DisallowWord(chars);
			if (svs != SqlValidationStatus.Ok)
			{
				return svs;
			}
		}
		return SqlValidationStatus.Ok;
	}
	// Returns true if the string representation of the sequence of characters in
	// chars is a SQL keyword.
	private SqlValidationStatus DisallowWord(List<char> chars)
	{
		if (chars.Count == 0)
		{
			return SqlValidationStatus.Ok;
		}
		string s = new String(chars.ToArray()).Trim();
		chars.Clear();
		return DisallowWord(s);
	}
	private SqlValidationStatus DisallowWord(string word)
	{
		if (word.Contains("--"))
		{
			return SqlValidationStatus.CommentNotAllowed;
		}
		if (_s_keywords.Contains(word))
		{
			return SqlValidationStatus.KeywordNotAllowed;
		}
		if (_statementCount > 0)
		{
			return SqlValidationStatus.SqlBatchNotAllowed;
		}
		if (word.Equals("go"))
		{
			_statementCount++;
		}
		return SqlValidationStatus.Ok;
	}
	private bool IsEmbeddedQuote(char curChar)
	{
		if (curChar != '\'' ||
				!IsQuotedString() ||
				IsQuotedIdentifier())
		{
			return false;
		}
		if (_literalQuotes.Peek() == curChar &&
				Peek() == curChar)
		{
			return true;
		}
		return false;
	}
	private bool IsQuotedString()
	{
		return _literalQuotes.Count > 0;
	}
	private bool IsQuotedIdentifier()
	{
		return _identifierQuotes.Count > 0;
	}
	private char Peek()
	{
		if (_pos + 1 &lt; _sql.Length)
		{
			return _sql[_pos + 1];
		}
		return '\0';
	}
}
