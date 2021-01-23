    public class EmpresaDao
    {
        private Empresa parent {get; set; }
        public EmpresaDao(Func<Empresa> parentConstructor)
        {
            this.parent = parentConstructor();    
        }
    }    
    static main()
    {
        var withEmpresaParent = new EmpresaDao(() => new Empresa());
        var withAssessoriaParent = new EmpresaDao(() => new Assessoria());
        ..
    }
