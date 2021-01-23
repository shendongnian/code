        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; } 
        public Domicilio Domicilio { get; set; } // residencial
        public Domicilio DomicilioComercial { get; set; }
        public Domicilio DomicilioFiscal { get; set; } // para envio de facturas o tramites
        public Telefono Telefono { get; set; }
        public Telefono Celular { get; set; }
        public Telefono Fax { get; set; }
        public Telefono TelComercial { get; set; }
        public Telefono TelDeposito { get; set; }
        public string Contacto { get; set; }
        public SituacionIva SituacionIva { get; set; } // Si es resp. inscripto, monotributista o exento
        public Identificacion Dni { get; set; }
        public Identificacion Cuil { get; set; }
        public Identificacion Cuit { get; set; }
        public Identificacion Lc { get; set; }
        public Identificacion Le { get; set; }
        public Identificacion Ci { get; set; }
        public ListaDePrecios ListaDePrecios { get; set; }
        public Vendedor Vendedor { get; set; }
        public string Actividad { get; set; }
        public Categoria Categoria { get; set; } // Si es cliente, provedor etc
        public Sexo Sexo { get; set; } // Masc o femenino        
        public string PagWeb { get; set; }
        public CuentaCorriente CuentaCorriente { get; set; }
        public string Observaciones { get; set; }
        public Identificacion Identificacion { get; set; }
    }
}
