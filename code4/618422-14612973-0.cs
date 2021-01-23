    public abstract class IFDB
    {
        public struct Estructura_TablaCuentasBancarias
        {
             // struct declaration
        }
        
        public Estructura_TablaCuentasBancarias structInstance;
    }
 
    class CntrDBSQLSRVCompac: IFDB
    {
        public void Foo()
        {
            // instance of the struct should be accessible like so
            this.structInstance
        }
    }
