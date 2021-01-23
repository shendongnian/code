     internal string ParameterNameFixed {
                get {
                    string parameterName = ParameterName;
                    if ((0 < parameterName.Length) && ('@' != parameterName[0])) {
                        parameterName = "@" + parameterName;
                    }
                    Debug.Assert(parameterName.Length <= TdsEnums.MAX_PARAMETER_NAME_LENGTH, "parameter name too long");
                    return parameterName;
                }
            }
