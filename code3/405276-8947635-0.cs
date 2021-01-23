    public override string ToString() {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(this.LastName);
        sb.Append(", ");
        sb.Append(this.FirstName);
        return sb.ToString();
    }
