      private string _Pwd;
                public string Pwd
                    {
                    get { return _Pwd; }
                    set { _Pwd = value;RaisePropertyChanged(()=>Pwd); }
                    }
