    public class Menu :EntidadePadrao
    {
        public int MenuId { get; set; }
    	public int MenuPai_ID {get; set; }
    	
        public Menu MenuPai { get; set; }
    	// other columns
        public virtual ICollection<Menu> MenusFilhos { get; set; }
        public virtual ICollection<PerfilUsuarioMenu> PerfisUsuario { get; set; }
    }
