    string XorEncryptDecryptText(string stringText, string stringKey){
    // Variable that receives the result of processode encryption.
    string stringNewText = &quot;&quot;;
    // First we take the difference in size of the two strings.
    int diff = (stringText.Length - stringKey.Length);
    // If the size difference that we put stringKey with the same size as the XOR stringText that no errors occur.
    if (diff &gt; 0){
        // We calculate the rest and the amount of times we repeat the stringKey to equal sizes.
        int cont = (int)diff / stringKey.Length;
        int resto = diff % stringKey.Length;
        string stringKeyAux = stringKey;
        // At this point the stringText concatenate the stringKey to be equal sizes.
        for (int i = 0; i &lt; cont; i++){
            stringKeyAux += stringKey;
        }
 
        for (int i = 0; (i &lt; resto); i++){
            stringKeyAux += stringKey[i];
        }
        stringKey = stringKeyAux;
    }
    // At this point piece of code is done the process of XOR.
    for (int i = 0; i &lt; stringText.Length; i++){
        int charValue = Convert.ToInt32(stringText[i]);
        int charKey = Convert.ToInt32(stringKey[i]);
        charValue ^= charKey;
        stringNewText += char.ConvertFromUtf32(charValue);
    }
    return stringNewText;}
    string XOREncriptDecriptFile(string FileName, string stringKey){
    string stringAux = System.IO.File.ReadAllLines(FileName);
    return XorEncryptDecryptText(stringAux, stringKey);}
