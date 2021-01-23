          class Save<T> : ISave
        {
            private readonly System.Action<T> _assignValue;
            private readonly System.Func<T> _getValue;
            public void Do()
            {
                T value = _getValue();
                if (!IsNullOrEmpty(value))
                {
                    _assignValue(value);
                }
            }
            public static Save<T> Value<T>(System.Func<T> getValue, System.Action<T> assignValue)
            {
                return new Save<T>(getValue, assignValue);
            }
            private Save(System.Func<T> getValue, System.Action<T> assignValue)
            {
                _getValue = getValue;
                _assignValue = assignValue;
            }
            private static bool IsNullOrEmpty<T>(T value)
            {
                if (typeof(T) == typeof(string))
                    return string.IsNullOrEmpty(value as string);
                return value.Equals(default(T));
            }
        }
        internal interface ISave
        {
            void Do();
        }
        public static void SaveUserData()
        {
            MWCompetitionContestantsDetails user = new MWCompetitionContestantsDetails();
            MWCompetitionsEntryDetails entry = new MWCompetitionsEntryDetails();
            new List<ISave>
            {
                Save<string>.Value( () => firstNameText.Value, x => user.FirstName = x),
                Save<string>.Value( () => lastNameText.Value, x => user.LastName = x),              
                Save<int>.Value( () => age.Value, x => user.Age = x),// int's supported :)              
                // etc
            }
            .ForEach(x => x.Do());
            user.Save();
        }
