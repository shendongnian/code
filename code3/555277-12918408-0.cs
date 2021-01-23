    public class CustomerCreditCardModelView {
    
        [Display(Name = "Número")]
        [Required(ErrorMessage = "El Número es requerido")]
        [StringLength(20, MinimumLength = 12, ErrorMessage = "El número parece ser incorrecto")]
        [JsonIgnore, ScriptIgnore]
        public string CardNumber { get; set; }
    
        [Display(Name = "Código de seguridad")]
        [Required(ErrorMessage = "El Código de seguridad es requerido")]
        public string CardSecurityCode { get; set; }
    
        [Display(Name = "Nombre en la tarjeta")]
        [Required(ErrorMessage = "El Nombre en la tarjeta es requerido")]
        public string NameOnCard { get; set; }
    
        [Display(Name = "Dirección de cobro")]
        [Required(ErrorMessage = "La Dirección de cobro es requerida")]
        public string BillingAddress { get; set; }
    
        [Display(Name = "Mes de vencimiento")]
        [Required(ErrorMessage = "El Mes de vencimiento es requerido")]
        public int? ExpirationMonth { get; set; }
    
        [Display(Name = "Año de vencimiento")]
        [Required(ErrorMessage = "El Año de vencimiento es requerido")]
        public int? ExpirationYear { get; set; }
    
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El documento es requerido")]
        public string Document { get; set; }
    
        [Display(Name = "Tipo de tarjeta")]
        public int IdCreditCard { get; set; }
    
        public int IdCustomer { get; set; }
        public bool IsDeleted { get; set; }
        public int IdCustomerCreditCard { get; set; }
        public CustomerCreditCardModelView() {
    
        }
    }
