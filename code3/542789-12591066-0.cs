                var dados = from a in db.Usuario
                        join b in db.Pessoa on a.PessoaID equals b.PessoaID
                        join c in db.TipoPessoa on b.TipoPessoaID equals c.TipoPessoaID
                        join d in db.Sexo on b.SexoID equals d.SexoID
                        select new
                        {
                            ID = a.UsuarioID,
                            Login = a.Login,
                            Fixo = a.Fixo,
                            Nome = b.Nome,
                            EmpresaID = a.EmpresaID,
                            Apagado = a.Apagado
                        };
            dados = dados.Where("(EmpresaID == " + _EmpresaID + " || EmpresaID == 0) && Apagado == \"N\"");
            dados = dados.OrderBy(sidx + " " + sord);
            dados = dados.Skip(pageIndex * pageSize);
            dados = dados.Take(pageSize);
