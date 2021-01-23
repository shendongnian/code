    public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                TUsuario userDTO= new TUSer()
                    {
                        Name = model.Name,
                        Login = model.Login,
                        Pass = model.Pass.ToString(CultureInfo.InvariantCulture),
                        Active = true,
                        IdCompany = model.IdCompany,
                        IdUserGroup = model.IdUserGroup,
                    };
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Login, model.Pass, new { IdUser = new UserDAL().Seq.NextVal(), Name = userDTO.Name, Login = userDTO.Login, Active = userDTO.Active, Pass = userDTO.Pass, IdCompany = userDTO.IdCompany, IdUserGroup = userDTO.IdUserGroup });
                    WebSecurity.Login(model.Login, model.Pass);
