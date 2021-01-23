    public class DapperModelBase
    {
        public abstract string PKField { get; }
        protected void OnPropertyValueChanged(string propertyName, object val)
        {
            var sql = string.Format("update {0} set {1} = @value where {2} = @id",
                this.GetType().Name,
                propertyName,
                this.PKField);
            IDbConnection conn = new SqlConnection("[some connection string]");
            conn.Execute(sql, new
                {
                    value = val,
                    id = this.GetType().GetProperty(this.PKField).GetValue(this, null)
                });
        }
    }
