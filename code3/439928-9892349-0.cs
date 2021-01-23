    %namespace LexScanner
    %option verbose, summary, noparser, unicode
    
    %x QUOTE
    %x COMMENT
    
    %{
        static string line = "";
        static List<string> butch = new List<string>();
        enum TokenType {
    		SL_COMMENT,
    		ML_COMMENT,
    		STRING,
    		WORD,
    		OTHER,
    		ending
        };
    %}
    
    dotchr [^\r\n] 
    eol (\r\n?|\n)
    %%
    \-\-[^\n]*$             { add(yytext, TokenType.SL_COMMENT); }
    
    \/\*                    { add(yytext, TokenType.ML_COMMENT); BEGIN(COMMENT); }
    <COMMENT>\*\/           { add(yytext, TokenType.ML_COMMENT); BEGIN(INITIAL); }
    <COMMENT>[^\*]+         { add(yytext, TokenType.ML_COMMENT); }
    <COMMENT>\*             { add(yytext, TokenType.ML_COMMENT); }
    
    \'                      { add(yytext, TokenType.STRING); BEGIN(QUOTE); }
    <QUOTE>\'\'             { add(yytext, TokenType.STRING); }
    <QUOTE>[^\']+           { add(yytext, TokenType.STRING); }
    <QUOTE>\'               { add(yytext, TokenType.STRING); BEGIN(INITIAL); }
    
    [gG][oO]                { push(); }
    
    [a-zA-Z0-9]+            { add(yytext, TokenType.WORD); }
    .                       { add(yytext, TokenType.OTHER); }
    \r?\n                   { add(yytext, TokenType.OTHER); }
    <<EOF>>                 { push(); }
    %%
