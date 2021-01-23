    public ActionResult Create2()
        {
            string login = User.Identity.Name;
            utilisateur ut = new utilisateur();
            var q = from j in db.utilisateurs where j.login == login select j;
            foreach (var i in q)
                ut = i;
            if ((ut.role.nom_role == "Stagiaire") || (ut.role.nom_role == "Developpeur"))
                return Redirect("~/Erreur");
            util u = new util();
            u.listesups = new MultiSelectList (db.utilisateurs, "id", "login");
            return View(u);
        }
    [HttpPost]
        public ActionResult Create2(FormCollection collection, util model)
        {
            var sups = collection["selectedusers"];
            string login = User.Identity.Name;
            utilisateur u = new utilisateur();
            List<int> nums = new List<int>();
            var q = from j in db.utilisateurs where j.login == login select j;
            utilisateur courant = new utilisateur();
            try
            {
                foreach (var i in q)
                {
                    courant = i;
                }
                foreach (var s in sups.Split(','))
                {
                    nums.Add(int.Parse(s));
                }
            }
            catch(Exception ex)
            {
                Logger.Warning(ex.Message, "aucun superieur selectionné");
            }
            try
            {
                foreach (var selecteduse in nums)
                {
                    utilisateur utilisateur = db.utilisateurs.Where(c => c.id == (int)selecteduse).FirstOrDefault();
                    u.superieur.Add(utilisateur);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, "Erreur ajout supérieurs");
            }
            //}
            if ((model.user.nom != null) && (model.user.prenom != null) && (model.user.login != null) && (model.user.email != null))
            {
                u.nom = model.user.nom;
                u.prenom = model.user.prenom;
                u.solde_conge = model.user.solde_conge;
                u.email = model.user.email;
                u.login = model.user.login;
                u.pwd = model.user.pwd;
                role role = new role();
                role = db.roles.Where(c => c.nom_role == model.nom_role).FirstOrDefault();
                u.role = role;
                try
                {
                    db.utilisateurs.AddObject(u);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message, "");
                }
                    ViewBag.id_role = new SelectList(db.roles, "id", "nom_role", model.user.id_role);
                return RedirectToAction("index");
            }
