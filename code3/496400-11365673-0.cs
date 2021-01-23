    [ServiceContract]
        public class WSBandeja : IWSBandeja
        {
            [OperationContract]
            public Compania.Linea getLinea()
            {
                Compania.Linea linea = new Compania.Linea();
                return linea.
            }
        }
