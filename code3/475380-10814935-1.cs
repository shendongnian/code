        public static User Connexion(String login, String MotDePasse, IDatabase bdd)
        {
            User us = bdd._Context.UserSet.FirstOrDefault(u => u.login == login);
            if (us == null)
                throw new Exception("Nom d'utilisateur erroné");
            if (us.password != MotDePasse)
                throw new Exception("Mot de passe erroné");
            else
                return us;
        }
