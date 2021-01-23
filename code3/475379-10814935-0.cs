        public static User Connexion(String login, String MotDePasse)
        {
            Database bdd = new Database(); // this is inline, concrete implementation, this cannot be mocked
            User us = bdd._Context.UserSet.FirstOrDefault(u => u.login == login);
            if (us == null)
                throw new Exception("Nom d'utilisateur erroné");
            if (us.password != MotDePasse)
                throw new Exception("Mot de passe erroné");
            else
                return us;
        }
