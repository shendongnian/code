    get {
                    try {
                        if (this[this.table.DateTimeColumn] is DBNull)
                        {
                            return Convert.ToDateTime(null);
                        }
                        else
                        {
                            return ((global::System.DateTime)(this[this.table.DateTimeColumn]));
                        }
                    }
                    catch (global::System.InvalidCastException e) { 
                        throw new global::System.Data.StrongTypingException("Description", e);                        
                    }
                }
                set {
                    this[this.table.DateTimeColumn] = value;
                }
