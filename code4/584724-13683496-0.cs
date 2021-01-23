    namespace Action
    {
        class Connect : IAction
        {
            static Connect ()
            {
                Reg.ClassDictionary.Add("connect", () => { return new Connect(); });
            }
            [JsonProperty("user")]
            public string Username;
            [JsonProperty("pass")]
            public string Password;
            public bool Exec()
            {
                return ConnectToServer(Username, Password);
            }
        }
    }
