     public static class VistaEntityManager 
    {
       static object _EntityInicial, _EntityFinal;
        public static object EntityFinal
        {
            get { return _EntityFinal; }
            set {
                Type tipo = ((object)value).GetType();
                _EntityFinal = Activator.CreateInstance(tipo);
                foreach (PropertyInfo pi in _EntityFinal.GetType().GetProperties())
                {
                    pi.SetValue(_EntityFinal, pi.GetValue(value, null), null);
                }
            }
        }
        public static object EntityInicial
        {
            get { return _EntityInicial; }
            set
            {
                Type tipo = ((object)value).GetType();
                _EntityInicial = Activator.CreateInstance(tipo);
                foreach (PropertyInfo pi in _EntityInicial.GetType().GetProperties())
                {
                    pi.SetValue(_EntityInicial, pi.GetValue(value, null), null);
                }
            }
        }
        /// <summary>
        /// Retorna as propriedades que tiveram seus valores alterados.
        /// </summary>
        /// <exception cref="EntityInicial e EntityFinal nulas"></exception>
        /// <exception cref="Entidades com tipos diferentes"></exception>
        /// <returns></returns>
        public static List<string> PropriedadesAlteradas()
        {
            if (_EntityFinal == null || _EntityInicial == null)
                throw new ArgumentNullException("A Entidade Final ou a Entidade Inicial está nula.");
            if (_EntityFinal.GetType() != _EntityInicial.GetType())
                throw new ArgumentException("Os tipos das entidades são diferentes.");
            List<string> propriedades = new List<string>();
            foreach (PropertyInfo p in _EntityInicial.GetType().GetProperties())
            {
                if (!Object.Equals(p.GetValue(_EntityInicial, null), p.GetValue(_EntityFinal, null)))
                    propriedades.Add(p.Name);
            }
            return propriedades;
        }
    }
      
