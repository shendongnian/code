    public class Controller
    {
        Model Model
        {
            get;
            set;
        }
        decimal CalculateSum()
        {
            return Model.Items.Aggregate((a, b) => a + b);
        }
    }
