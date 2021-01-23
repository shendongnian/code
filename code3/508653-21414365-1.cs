    public static class TimeExtensions
    {
        private static Assembly _sysAssembly;
        private static Type _dateTimeParseType, _dateTimeResultType;
        private static MethodInfo _tryParseMethod, _dateTimeResultInitMethod;
        private static FieldInfo _dateTimeResultParsedDateField,
                    _dateTimeResultHourField, _dateTimeResultMinuteField, _dateTimeResultSecondField;
        /// <summary>
        /// This private method initializes the private fields that store reflection information
        /// that is used in this class.  The method is designed so that it only needs to be called
        /// one time.
        /// </summary>
        private static void InitializeReflection()
        {
            // Get a reference to the Assembly containing the 'System' namespace
            _sysAssembly = typeof(DateTime).Assembly;
            // Get non-public types of 'System' namespace
            _dateTimeParseType = _sysAssembly.GetType("System.DateTimeParse");
            _dateTimeResultType = _sysAssembly.GetType("System.DateTimeResult");
            // Array of types for matching the proper overload of method System.DateTimeParse.TryParse
            Type[] argTypes = new Type[] 
            {
                typeof(String), 
                typeof(DateTimeFormatInfo), 
                typeof(DateTimeStyles), 
                _dateTimeResultType.MakeByRefType()
            };
            _tryParseMethod = _dateTimeParseType.GetMethod("TryParse",
                    BindingFlags.Static | BindingFlags.NonPublic, null, argTypes, null);
            _dateTimeResultInitMethod = _dateTimeResultType.GetMethod("Init",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            _dateTimeResultParsedDateField = _dateTimeResultType.GetField("parsedDate",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            _dateTimeResultHourField = _dateTimeResultType.GetField("Hour",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            _dateTimeResultMinuteField = _dateTimeResultType.GetField("Minute",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            _dateTimeResultSecondField = _dateTimeResultType.GetField("Second",
                    BindingFlags.Instance | BindingFlags.NonPublic);
        } 
        /// <summary>
        /// This method converts the given string representation of a date and time to its DateTime
        /// equivalent and returns true if the conversion succeeded or false if no conversion could be
        /// done.  The method is a close imitation of the System.DateTime.TryParse method, with the
        /// exception that this method takes a parameter that allows the caller to specify what the time
        /// value should be when the given string contains no time-of-day information.  In contrast,
        /// the method System.DateTime.TryParse will always apply a value of midnight (beginning of day)
        /// when the given string contains no time-of-day information.
        /// </summary>
        /// <param name="s">the string that is to be converted to a DateTime</param>
        /// <param name="result">the DateTime equivalent of the given string</param>
        /// <param name="defaultTime">a DateTime object whose Hour, Minute, and Second values are used
        /// as the default in the 'result' parameter.  If the 's' parameter contains time-of-day 
        /// information, then it overrides the value of 'defaultTime'</param>
        public static Boolean TryParse(String s, out DateTime result, DateTime defaultTime)
        {
            // Value of the result if no conversion can be done
            result = DateTime.MinValue;
            // Create the buffer that stores the parsed result
            if (_sysAssembly == null) InitializeReflection();
            dynamic resultData = Activator.CreateInstance(_dateTimeResultType);
            _dateTimeResultInitMethod.Invoke(resultData, new Object[] { });
            // Override the default time values of the buffer, using this method's parameter
            _dateTimeResultHourField.SetValue(resultData, defaultTime.Hour);
            _dateTimeResultMinuteField.SetValue(resultData, defaultTime.Minute);
            _dateTimeResultSecondField.SetValue(resultData, defaultTime.Second);
            // Create array parameters that can be passed (using reflection) to 
            // the non-public method DateTimeParse.TryParse, which does the real work
            Object[] tryParseParams = new Object[]
            {
                s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, resultData
            };
            // Call non-public method DateTimeParse.TryParse
            Boolean success = (Boolean)_tryParseMethod.Invoke(null, tryParseParams);
            if (success)
            {
                // Because the DateTimeResult object was passed as a 'ref' parameter, we need to
                // pull its new value out of the array of method parameters
                result = _dateTimeResultParsedDateField.GetValue((dynamic)tryParseParams[3]);
                return true;
            }
            return false;
        }
    }
