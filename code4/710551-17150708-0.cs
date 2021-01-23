        public static string Open_form(string Var)
        {
            using (FormX Obj = new FormX())
            {
                Obj.Var = Var;
                Obj.ShowDialog();
                Obj.Process_Var();
                return Obj.Var;
            }
        }
