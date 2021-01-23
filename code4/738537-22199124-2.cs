            public object DataSource
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get
            {
                return this.dataSource;
            }
            set
            {
                if (((value != null) && !(value is IList)) && !(value is IListSource))
                {
                    throw new ArgumentException(System.Windows.Forms.SR.GetString("BadDataSourceForComplexBinding"));
                }
                if (this.dataSource != value)
                {
                    try
                    {
                        this.SetDataConnection(value, this.displayMember, false);
                    }
                    catch
                    {
                        this.DisplayMember = "";
                    }
                    if (value == null)
                    {
                        this.DisplayMember = "";
                    }
                }
            }
        }
