        private static List<ParameterInformation> GetParameterInfoList(IMethodCallMessage methodCallMessage)
        {
            var = new List<ParameterInformation>();
            
            // Note: This works even if a parameter's value is null.
            for(int i = 0 ; i < methodCallMessage.ArgCount ; i++)
            {
                parameterInformationList.Add(new ParameterInformation(methodCallMessage.GetArgName(i), methodCallMessage.Args[i]));
            }
            return parameterInformationList;
        }
