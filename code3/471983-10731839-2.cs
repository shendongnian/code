    public class Сотрудник {
        ...
        public int appointmnet_id { get; set; }
        [ForeignKey(appointment_id)]
        public Должность appointment { get; set; }
    }
