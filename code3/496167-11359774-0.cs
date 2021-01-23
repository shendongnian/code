    public class ClassFromOtherAssembly
    {
        private IPrincipal principal;
        public ClassFromOtherAssembly(IPrincipal principal)
        {
            this.principal = principal;
        }
        public List<Documents> GetDocuments()
        {
            //Security check
            if (principal.IsInRole("Admin"))
            {
                //return the list
            }
            else
            {
                //return empty list
            }
        }
    }
