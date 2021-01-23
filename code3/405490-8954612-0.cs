    #region Fields
    /// <summary>
    /// Field Declaration for the <see cref="name"/>
    /// </summary>
    private string _Name;
    #endregion
    #region Properties
    /// <summary>
    /// Gets or Sets the name
    /// </summary>
    public string Name
    {
        get { return _Name; }
        set
        {
            if (this._Name != value)
            {
                this._Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
    #endregion
