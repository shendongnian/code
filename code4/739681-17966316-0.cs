    if(_ReaderLines.Read())
    {
        if (!_ReaderLines.IsDbNull("ParStrP1"))
        {
            lienBaseConnaissance = _ReaderLines.GetString("ParStrP1");
            return lienBaseConnaissance;
        }
        else
        {
            return null;
        }
    }
    else
        return null;
