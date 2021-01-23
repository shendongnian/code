    const int SYNTAX_MASK = 1 << 12;
    if (scode & SYNTAX_MASK != 0)
    {
        //It's a syntax error
        scriptError.GetSourceLine(out sourceLine);
    }
    else
    {
        //It's a logic error
    }
