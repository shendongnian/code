    public static string VerificaExame(string desc)
    {
        var model = new ExameContext();
        object res = (object)model.DbExame.Where(exame => exame.Descricao.Trim() == desc.Trim())
                                    .Select(exame => new { Id = exame.Id, Codigo = exame.Codigo })
                                    .FirstOrDefault()
            ??
            (object)model.DbExame.Where(exame => exame.Codigo.Trim() == desc.Trim())
                            .Select(exame => new { Id = exame.Id, Descricao = exame.Descricao })
                            .FirstOrDefault();
            
        if (res != null)
            return JsonConvert.SerializeObject(res);
        return JsonConvert.SerializeObject("");//Or throw an exception
    }
