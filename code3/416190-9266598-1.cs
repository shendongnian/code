            for(int i = 0; i < paramValues.Length; i++)
            {
                if(  string.IsNullOrEmpty( paramValues[i].Trim()) )
                {
                    paramValues[i] = currentParameterInfos[i].DefaultValue.ToString();
                }
            } 
