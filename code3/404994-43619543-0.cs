        public ElapsedEventArgs CreateElapsedEventArgs(DateTime signalTime)
        {
            var e = FormatterServices.GetUninitializedObject(typeof(ElapsedEventArgs)) as ElapsedEventArgs;
            if (e != null)
            {
                var fieldInfo = e.GetType().GetField("signalTime", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(e, signalTime);
                }
            }
            return e;
        }
    
