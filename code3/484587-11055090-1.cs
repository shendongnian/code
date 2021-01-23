    public string generatedScript = string.empty;
    
    public string Iterations() {
        string generatedScript = "GetMap(); \n";
        //assetRow is an array of strings. The strings are in the format "var1, var2, var3"
        for (i=0; i<numberOfAssets; i++)
        {
            generatedScript = generatedScript + "AssetDescription("+assetRow[i]+"); \n";
        }
    }
