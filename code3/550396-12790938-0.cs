    public enum OrderStatus {
        NOT_SHIPPED,
        SHIPPED
    }
    public class ViewModel {
        public OrderStatus SelectedStatus { get; set; }
        public List<StatusViewModel> Models = new List<StatusViewModel>();
    }
    public class StatusViewModel {
        public string StringStatus { get; set; }
        public OrderStatus EnumStatus { get; set; }
    }
