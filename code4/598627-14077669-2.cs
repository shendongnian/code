    public class Menu :EntidadePadrao
    {
        public int MenuId { get; set; }
    	public int MenuPai_ID {get; set; }
    	
        // Navigation List
        public Menu MenuPai { get; set; }
        public virtual ICollection<Menu> MenusFilhos { get; set; }
        public virtual ICollection<PerfilUsuarioMenu> PerfisUsuario { get; set; }
    }
