    public void GenericWebServeceMethod(int version, string encodedXMLParameters)
    {
        string xmlParameters = HTMLDecode(encodedParameters);
        
        switch(version)
        {
            case 1:
                ParameterType1 p1 = DecodeVersion1XML(xmlParameters);
                MethodVersion1(p1);
                break;
            case 2:
                ParameterType2 p2 = DecodeVersion2XML(xmlParameters);
                MethodVersion2(p2);
                break;
        }
    }
