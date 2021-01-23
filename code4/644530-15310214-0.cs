    public bool IsAccept {
        get {
            return String.IsNullOrEmpty( this.Status ) ? false : this.Status.Equals("accept", StringComparison.OrdinalIgnoreCase);
        }
    }
    public bool IsRefer {
        get {
            return String.IsNullOrEmpty( this.Status ) ? false : this.Status.Equals("refer", StringComparison.OrdinalIgnoreCase);
        }
    }
    public bool IsAnyReviewState {
        get {
            return this.IsAccept || this.IsRefer;
        }
    }
