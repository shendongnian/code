                "{controller}/{action}/{param1}/{param2}/{param3}"
                "{controller}/{action}/{param1}/{param2}"
                "{controller}/{action}/{param1}"
    
        public ActionResult Index(string param1, string param2, string param3)
        {
            string param = string.Concat(param1, param2, param3);
