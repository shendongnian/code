    int round(float nNumToRound)
    {
    // Variable definition
    int nResult;
    // Check if the number is negetive
    if (nNumToRound > 0)
    {
        // its positive, use floor.
        nResult = floor(nNumToRound + 0.5);
    }
    else if (nNumToRound < 0)
    {
        // its negtive, use ceil 
        nResult = ceil(nNumToRound - 0.5);
    }
    return (nResult);
}
