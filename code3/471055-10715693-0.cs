    /// <summary>
            /// Gets or sets the associated <see cref="tblCustomer"/> entity.
            /// </summary>
            [Association("tblCustomer_tblInvoice", "uiCustomerId", "Id", IsForeignKey=true)]
            [XmlIgnore()]
            public tblCustomer tblCustomer
            {
                get
                {
                    if ((this._tblCustomer == null))
                    {
                        this._tblCustomer = new EntityRef<tblCustomer>(this, "tblCustomer", this.FiltertblCustomer);
                    }
                    return this._tblCustomer.Entity;
                }
                set
                {
                    tblCustomer previous = this.tblCustomer;
                    if ((previous != value))
                    {
                        this.ValidateProperty("tblCustomer", value);
                        if ((previous != null))
                        {
                            this._tblCustomer.Entity = null;
                            previous.tblInvoices.Remove(this);
                        }
                        if ((value != null))
                        {
                            this.uiCustomerId = value.Id;
                        }
                        else
                        {
                            this.uiCustomerId = default(Guid);
                        }
                        this._tblCustomer.Entity = value;
                        if ((value != null))
                        {
                            value.tblInvoices.Add(this);
                        }
                        this.RaisePropertyChanged("tblCustomer");
                    }
                }
            }
