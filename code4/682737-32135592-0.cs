    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; } 
    }
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
