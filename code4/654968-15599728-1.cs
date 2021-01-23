    public int Program()
    {
        lex.GetNextToken();
            if (lex.InternalCode == TokenTable.UNIT)
            {
                lex.GetNextToken();
                ProgIdentifier();
                if (lex.InternalCode == TokenTable.SEMICOLON)
                {
                    lex.GetNextToken();
                    Block();
                    if (parseErrors)
                    {
                        //Drop out into Statement Level Parsing
                        //Statement Level Parsing just calls Statement() for <statement>
                        //until you have gone through the entire input.
                        //The point is to avoid getting many errors if you are missing a
                        //single token.
                        StatementLevelParse();
                    }
                    if (lex.InternalCode == TokenTable.PERIOD)
                    {
                        lex.GetNextToken();
                        if (lex.EndOfFile)
                        {
                            if (!parseFailed)
                            {
                                //Success
                                echo("Success");
                            }
                            else
                            {
                                echo("Parse Failed");
                            }
                        }
                        else
                        {
                            Error(lex.CurrentLine, 200, false, "Expected End Of File: Found " + lex.NextSymbol);
                        }
                    }
                    else
                    {
                        //Fail. Expected $PERIOD
                        Error(lex.CurrentLine, 200, false, "Expected \".\": Found " + lex.NextSymbol);
                    }
                }
                else
                {
                    //Fail. Expected $SEMICOLON
                    Error(lex.CurrentLine, 200, false, "Expected \";\": Found " + lex.NextSymbol);
                }
            }
            else
            {
                //Fail. Expected $UNIT
                Error(lex.CurrentLine, 200, false, "Expected \"UNIT\": Found " + lex.NextSymbol);
            }
            EchoOutput("LEAVING PROGRAM");
            return 0;
    }
